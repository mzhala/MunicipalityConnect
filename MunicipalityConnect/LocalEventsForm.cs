using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalityConnect
{
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void pnlFeaturedEvents_Paint(object sender, PaintEventArgs e)
        {

        }

        // Event handler for the Search button click event.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            string category = comboBox_category.SelectedItem?.ToString()
                ?? "All categories";

            string selectedDate = comboBox_date.SelectedItem?.ToString()
                ?? "All dates";

            string location = comboBox_location.SelectedItem?.ToString()
                ?? "All locations";

            DateTime parsedDate = DateTime.MinValue;
            bool filterByDate = DateTime.TryParseExact(
                selectedDate,
                "dd MMM yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out parsedDate);

            List<CommunityEvent> results = allEvents.Where(ev =>
                // Ignore keyword filtering if the search box is empty.
                (string.IsNullOrWhiteSpace(keyword) ||
                 ev.EventName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                 ev.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                 ev.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                 ev.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase)) &&

                // Ignore category filtering when All categories is selected.
                (category == "All categories" || ev.Category == category) &&

                // Ignore date filtering when All dates is selected.
                (!filterByDate || ev.EventDate.Date == parsedDate.Date) &&

                // Ignore location filtering when All locations is selected.
                (location == "All locations" || ev.Location == location)
            ).ToList();

            RecordSearchPreference(keyword, category, location);
            DisplayEvents(results);
            DisplayRecommendations();
        }

        // Event handler for the filter ComboBox selection change event.
        private void PopulateFilters()
        {
            // Prevent event handlers from firing while the lists are being populated.
            comboBox_category.SelectedIndexChanged -= Filter_SelectedIndexChanged;
            comboBox_date.SelectedIndexChanged -= Filter_SelectedIndexChanged;
            comboBox_location.SelectedIndexChanged -= Filter_SelectedIndexChanged;

            // Populate distinct categories.
            comboBox_category.Items.Clear();
            comboBox_category.Items.Add("All categories");

            foreach (string category in allEvents
                .Select(ev => ev.Category)
                .Where(category => !string.IsNullOrWhiteSpace(category))
                .Distinct()
                .OrderBy(category => category))
            {
                comboBox_category.Items.Add(category);
            }

            // Populate distinct event dates.
            comboBox_date.Items.Clear();
            comboBox_date.Items.Add("All dates");

            foreach (DateTime date in allEvents
                .Select(ev => ev.EventDate.Date)
                .Distinct()
                .OrderBy(date => date))
            {
                comboBox_date.Items.Add(date.ToString("dd MMM yyyy"));
            }

            // Populate distinct locations.
            comboBox_location.Items.Clear();
            comboBox_location.Items.Add("All locations");

            foreach (string location in allEvents
                .Select(ev => ev.Location)
                .Where(location => !string.IsNullOrWhiteSpace(location))
                .Distinct()
                .OrderBy(location => location))
            {
                comboBox_location.Items.Add(location);
            }

            // Select the All option by default.
            comboBox_category.SelectedIndex = 0;
            comboBox_date.SelectedIndex = 0;
            comboBox_location.SelectedIndex = 0;

            // Attach handlers after population is complete.
            //comboBox_category.SelectedIndexChanged += Filter_SelectedIndexChanged;
            //comboBox_date.SelectedIndexChanged += Filter_SelectedIndexChanged;
            //comboBox_location.SelectedIndexChanged += Filter_SelectedIndexChanged;
        }

        // Event handler for the filter ComboBox selection change event.
        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Search again using the currently selected filters.
            btnSearch_Click(sender, e);
        }

        // Event handler for the DataGridView cell content click event to view event details.
        private void dataGridView_events_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGridView_events.Columns[e.ColumnIndex].Name != "btnViewDetails")
            {
                return;
            }

            int eventId = Convert.ToInt32(
                dataGridView_events.Rows[e.RowIndex].Cells["EventId"].Value);

            if (eventDictionary.TryGetValue(eventId, out CommunityEvent ev))
            {
                recentlyViewedEvents.Push(ev);

                // debug
                System.Diagnostics.Debug.WriteLine(
                     $"Recently viewed: {recentlyViewedEvents.Peek().EventName}");

                MessageBox.Show(
                    $"Event: {ev.EventName}\n" +
                    $"Category: {ev.Category}\n" +
                    $"Date: {ev.EventDate:dd MMM yyyy}\n" +
                    $"Location: {ev.Location}\n\n" +
                    ev.Description,
                    "Event Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // Class representing a community event.

        public class CommunityEvent
        {
            public int EventId { get; set; }
            public string EventName { get; set; } = "";
            public string Category { get; set; } = "";
            public DateTime EventDate { get; set; }
            public string Location { get; set; } = "";
            public string Description { get; set; } = "";
        }

        private List<CommunityEvent> allEvents = new List<CommunityEvent>();

        // Dictionary for retrieving an event using its unique ID.
        private Dictionary<int, CommunityEvent> eventDictionary =
            new Dictionary<int, CommunityEvent>();

        // Sorted dictionary organises events by date.
        private SortedDictionary<DateTime, List<CommunityEvent>> eventsByDate =
            new SortedDictionary<DateTime, List<CommunityEvent>>();

        private void LoadEvents()
        {
            allEvents = new List<CommunityEvent>
            {
                new CommunityEvent
                {
                    EventId = 1,
                    EventName = "Community Clean-Up Day",
                    Category = "Environment",
                    EventDate = new DateTime(2026, 10, 24),
                    Location = "Durban Central",
                    Description = "Help keep our community clean."
                },
                new CommunityEvent
                {
                    EventId = 2,
                    EventName = "Small Business Workshop",
                    Category = "Business",
                    EventDate = new DateTime(2026, 10, 27),
                    Location = "Durban",
                    Description = "Learn practical business skills."
                },
                new CommunityEvent
                {
                    EventId = 3,
                    EventName = "Community Health Awareness",
                    Category = "Health",
                    EventDate = new DateTime(2026, 10, 31),
                    Location = "Umlazi",
                    Description = "Learn about healthy living."
                },
                new CommunityEvent
                {
                    EventId = 4,
                    EventName = "Youth Skills Development",
                    Category = "Education",
                    EventDate = new DateTime(2026, 11, 4),
                    Location = "Pinetown",
                    Description = "Explore skills development opportunities."
                },
                new CommunityEvent
                {
                    EventId = 5,
                    EventName = "Community Safety Meeting",
                    Category = "Community",
                    EventDate = new DateTime(2026, 11, 7),
                    Location = "Durban North",
                    Description = "Discuss local safety concerns."
                }

            };

            // Clear existing data structures before populating them.
            eventDictionary.Clear();
            eventsByDate.Clear();

            // Populate the eventDictionary and eventsByDate for efficient retrieval and filtering.
            foreach (CommunityEvent ev in allEvents)
            {
                eventDictionary[ev.EventId] = ev;

                if (!eventsByDate.ContainsKey(ev.EventDate.Date))
                {
                    eventsByDate[ev.EventDate.Date] = new List<CommunityEvent>();
                }

                eventsByDate[ev.EventDate.Date].Add(ev);
            }

            // Populate the filter ComboBoxes with distinct values from the loaded events.
            PopulateFilters();
            DisplayEvents(GetEventsByDate());

            // Populate the queue with upcoming events in chronological order.
            upcomingEvents.Clear();

            foreach (CommunityEvent ev in allEvents
                .Where(ev => ev.EventDate.Date >= DateTime.Today)
                .OrderBy(ev => ev.EventDate))
            {
                upcomingEvents.Enqueue(ev);
            }

            // Store unique event categories.
            eventCategories.Clear();

            foreach (CommunityEvent ev in allEvents)
            {
                if (!string.IsNullOrWhiteSpace(ev.Category))
                {
                    eventCategories.Add(ev.Category);
                }
            }

        }

        private void DisplayEvents(List<CommunityEvent> eventsToDisplay)
        {
            dataGridView_events.DataSource = null;

            dataGridView_events.DataSource = eventsToDisplay
                .Select(ev => new
                {
                    ev.EventId,
                    ev.EventName,
                    ev.Category,
                    Date = ev.EventDate.ToString("dd MMM yyyy"),
                    ev.Location,
                    ev.Description
                })
                .ToList();
        }

        // Event handler for the Clear button click event.
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            comboBox_category.SelectedIndex = 0;
            comboBox_date.SelectedIndex = 0;
            comboBox_location.SelectedIndex = 0;

            DisplayEvents(GetEventsByDate());
        }


        private Stack<CommunityEvent> recentlyViewedEvents =
            new Stack<CommunityEvent>();

        // Queue manages upcoming events in date order (FIFO).
        private Queue<CommunityEvent> upcomingEvents =
            new Queue<CommunityEvent>();

        // HashSet stores each category only once.
        private HashSet<string> eventCategories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Records how often users search for each term or category.
        private Dictionary<string, int> searchHistory =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // Records the user's search preference based on the most specific filter applied.
        private void RecordSearchPreference(string keyword, string category, string location)
        {
            string preference = "";

            // Prioritise a selected category.
            if (category != "All categories")
            {
                preference = category;
            }
            else if (location != "All locations")
            {
                preference = location;
            }
            else if (!string.IsNullOrWhiteSpace(keyword))
            {
                preference = keyword.Trim();
            }

            // Do not record searches with no meaningful filter.
            if (string.IsNullOrWhiteSpace(preference))
                return;

            if (searchHistory.ContainsKey(preference))
                searchHistory[preference]++;
            else
                searchHistory[preference] = 1;
        }

        // Displays relevant recommendations in a table,
        // excluding events already shown in the main results table.
        private void DisplayRecommendations()
        {
            dataGridView_recommendations.DataSource = null;

            // Do not generate recommendations before a preference is recorded.
            if (searchHistory.Count == 0)
                return;

            // Get the user's most frequently searched preferences.
            var preferences = searchHistory
                .OrderByDescending(item => item.Value)
                .Select(item => item.Key)
                .ToList();

            // Get the event IDs currently displayed in the main table.
            var displayedEventIds = dataGridView_events.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["EventId"].Value != null)
                .Select(row => Convert.ToInt32(row.Cells["EventId"].Value))
                .ToHashSet();

            // Score events that are not already displayed.
            var recommendations = allEvents
                .Where(ev => !displayedEventIds.Contains(ev.EventId))
                .Select(ev => new
                {
                    Event = ev,
                    Score = preferences.Sum(preference =>
                        (ev.Category.Contains(preference,
                            StringComparison.OrdinalIgnoreCase) ? 3 : 0) +
                        (ev.EventName.Contains(preference,
                            StringComparison.OrdinalIgnoreCase) ? 2 : 0) +
                        (ev.Location.Contains(preference,
                            StringComparison.OrdinalIgnoreCase) ? 1 : 0) +
                        (ev.Description.Contains(preference,
                            StringComparison.OrdinalIgnoreCase) ? 1 : 0))
                })
                .Where(item => item.Score > 0)
                .OrderByDescending(item => item.Score)
                .ThenBy(item => item.Event.EventDate)
                .Take(3)
                .Select(item => new
                {
                    item.Event.EventName,
                    item.Event.Category,
                    Date = item.Event.EventDate.ToString("dd MMM yyyy"),
                    item.Event.Location
                })
                .ToList();

            // Display the recommendations in the table.
            dataGridView_recommendations.DataSource = recommendations;
        }

        // Returns events grouped by date, in chronological order.
        private List<CommunityEvent> GetEventsByDate()
        {
            return eventsByDate
                .SelectMany(group => group.Value)
                .ToList();
        }

        // Displays details when the View Details button is clicked
        // in the recommendations table.
        private void dataGridView_recommendations_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                dataGridView_recommendations.Columns[e.ColumnIndex].Name != "btnViewDetailsRecommended")
            {
                return;
            }

            string eventName = dataGridView_recommendations
                .Rows[e.RowIndex].Cells["EventName"].Value?.ToString() ?? "";

            CommunityEvent ev = allEvents.FirstOrDefault(
                item => item.EventName == eventName);

            if (ev == null)
                return;

            recentlyViewedEvents.Push(ev);

            MessageBox.Show(
                $"Event: {ev.EventName}\n" +
                $"Category: {ev.Category}\n" +
                $"Date: {ev.EventDate:dd MMM yyyy}\n" +
                $"Location: {ev.Location}\n\n" +
                ev.Description,
                "Event Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Hide();
        }
    }
}
