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
        // =========================================================
        // DATA MODEL
        // =========================================================

        // Represents a community event.
        public class CommunityEvent
        {
            public int EventId { get; set; }
            public string EventName { get; set; } = "";
            public string Category { get; set; } = "";
            public DateTime EventDate { get; set; }
            public string Location { get; set; } = "";
            public string Description { get; set; } = "";
        }

        // =========================================================
        // DATA STRUCTURES
        // =========================================================

        // Stores all available events.
        private List<CommunityEvent> allEvents = new List<CommunityEvent>();

        // Retrieves an event using its unique ID.
        private Dictionary<int, CommunityEvent> eventDictionary =
            new Dictionary<int, CommunityEvent>();

        // Groups events by date in chronological order.
        private SortedDictionary<DateTime, List<CommunityEvent>> eventsByDate =
            new SortedDictionary<DateTime, List<CommunityEvent>>();

        // Records recently viewed events (last viewed event is on top).
        private Stack<CommunityEvent> recentlyViewedEvents =
            new Stack<CommunityEvent>();

        // Stores upcoming events in chronological order (FIFO).
        private Queue<CommunityEvent> upcomingEvents =
            new Queue<CommunityEvent>();

        // Stores each category only once.
        private HashSet<string> eventCategories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Records how often users search for each preference.
        private Dictionary<string, int> searchHistory =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        // =========================================================
        // FORM INITIALISATION
        // =========================================================

        public LocalEventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void pnlFeaturedEvents_Paint(object sender, PaintEventArgs e)
        {
        }

        // =========================================================
        // SEARCH AND FILTERS
        // =========================================================

        // Handles the Search button click event.
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

        // Populates the filter ComboBoxes using the loaded event data.
        private void PopulateFilters()
        {
            // Prevent event handlers from firing while lists are populated.
            comboBox_category.SelectedIndexChanged -= Filter_SelectedIndexChanged;
            comboBox_date.SelectedIndexChanged -= Filter_SelectedIndexChanged;
            comboBox_location.SelectedIndexChanged -= Filter_SelectedIndexChanged;

            // Populate categories using the HashSet to avoid duplicates.
            comboBox_category.Items.Clear();
            comboBox_category.Items.Add("All categories");

            foreach (string category in eventCategories.OrderBy(category => category))
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

            // These handlers remain unsubscribed because filtering is manual.
            // comboBox_category.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // comboBox_date.SelectedIndexChanged += Filter_SelectedIndexChanged;
            // comboBox_location.SelectedIndexChanged += Filter_SelectedIndexChanged;
        }

        // Kept as the ComboBox selection-change handler.
        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Search again using the currently selected filters.
            btnSearch_Click(sender, e);
        }

        // Clears the search and restores all events.
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            comboBox_category.SelectedIndex = 0;
            comboBox_date.SelectedIndex = 0;
            comboBox_location.SelectedIndex = 0;

            DisplayEvents(GetEventsByDate());
        }

        // =========================================================
        // LOAD AND ORGANISE EVENT DATA
        // =========================================================

        private void LoadEvents()
        {
            allEvents = new List<CommunityEvent>
{
            // Environment
            new CommunityEvent
            {
                EventId = 1,
                EventName = "Community Clean-Up Day",
                Category = "Environment",
                EventDate = new DateTime(2026, 10, 24),
                Location = "Durban Central",
                Description = "Join residents in cleaning public spaces and keeping our community clean."
            },
            new CommunityEvent
            {
                EventId = 2,
                EventName = "Tree Planting Initiative",
                Category = "Environment",
                EventDate = new DateTime(2026, 11, 14),
                Location = "Pinetown",
                Description = "Help plant trees and learn about protecting the local environment."
            },
            new CommunityEvent
            {
                EventId = 3,
                EventName = "Recycling Awareness Campaign",
                Category = "Environment",
                EventDate = new DateTime(2026, 12, 5),
                Location = "Umlazi",
                Description = "Learn how to separate recyclable waste and reduce household waste."
            },

            // Business
            new CommunityEvent
            {
                EventId = 4,
                EventName = "Small Business Workshop",
                Category = "Business",
                EventDate = new DateTime(2026, 10, 27),
                Location = "Durban",
                Description = "Learn practical business skills, financial planning, and customer management."
            },
            new CommunityEvent
            {
                EventId = 5,
                EventName = "Entrepreneurship Information Session",
                Category = "Business",
                EventDate = new DateTime(2026, 11, 19),
                Location = "KwaMashu",
                Description = "Discover resources and opportunities available to aspiring entrepreneurs."
            },
            new CommunityEvent
            {
                EventId = 6,
                EventName = "Local Market and Business Expo",
                Category = "Business",
                EventDate = new DateTime(2026, 12, 12),
                Location = "Durban North",
                Description = "Meet local business owners and explore products and services from community businesses."
            },

            // Health
            new CommunityEvent
            {
                EventId = 7,
                EventName = "Community Health Awareness",
                Category = "Health",
                EventDate = new DateTime(2026, 10, 31),
                Location = "Umlazi",
                Description = "Learn about healthy living, preventive care, and available community health services."
            },
            new CommunityEvent
            {
                EventId = 8,
                EventName = "Blood Donation Drive",
                Category = "Health",
                EventDate = new DateTime(2026, 11, 21),
                Location = "Durban Central",
                Description = "Support local healthcare services by participating in a community blood donation drive."
            },
            new CommunityEvent
            {
                EventId = 9,
                EventName = "Community Fitness Day",
                Category = "Health",
                EventDate = new DateTime(2027, 1, 16),
                Location = "Westville",
                Description = "Take part in outdoor exercise activities promoting healthy and active lifestyles."
            },

            // Education
            new CommunityEvent
            {
                EventId = 10,
                EventName = "Youth Skills Development",
                Category = "Education",
                EventDate = new DateTime(2026, 11, 4),
                Location = "Pinetown",
                Description = "Explore skills development opportunities and resources for young people."
            },
            new CommunityEvent
            {
                EventId = 11,
                EventName = "Digital Literacy Workshop",
                Category = "Education",
                EventDate = new DateTime(2026, 11, 28),
                Location = "KwaMashu",
                Description = "Learn basic computer skills, internet safety, and how to access online services."
            },
            new CommunityEvent
            {
                EventId = 12,
                EventName = "Career Guidance Day",
                Category = "Education",
                EventDate = new DateTime(2027, 1, 23),
                Location = "Durban",
                Description = "Explore career paths, training programmes, and further education opportunities."
            },

            // Community
            new CommunityEvent
            {
                EventId = 13,
                EventName = "Community Safety Meeting",
                Category = "Community",
                EventDate = new DateTime(2026, 11, 7),
                Location = "Durban North",
                Description = "Discuss neighbourhood safety concerns and ways to improve community cooperation."
            },
            new CommunityEvent
            {
                EventId = 14,
                EventName = "Residents Association Meeting",
                Category = "Community",
                EventDate = new DateTime(2026, 11, 25),
                Location = "Westville",
                Description = "Discuss local concerns, community priorities, and proposed improvement initiatives."
            },
            new CommunityEvent
            {
                EventId = 15,
                EventName = "Community Volunteer Day",
                Category = "Community",
                EventDate = new DateTime(2026, 12, 19),
                Location = "Umlazi",
                Description = "Volunteer your time to support local community projects and residents."
            },

            // Municipal Services
            new CommunityEvent
            {
                EventId = 16,
                EventName = "Municipal Services Information Day",
                Category = "Municipal Services",
                EventDate = new DateTime(2026, 11, 11),
                Location = "Durban Central",
                Description = "Learn how to access municipal services and submit service requests."
            },
            new CommunityEvent
            {
                EventId = 17,
                EventName = "Water Conservation Awareness",
                Category = "Municipal Services",
                EventDate = new DateTime(2026, 12, 2),
                Location = "Pinetown",
                Description = "Learn about water conservation, responsible water use, and reporting water leaks."
            },
            new CommunityEvent
            {
                EventId = 18,
                EventName = "Electricity Safety Information Session",
                Category = "Municipal Services",
                EventDate = new DateTime(2027, 1, 9),
                Location = "KwaMashu",
                Description = "Learn about electrical safety and the correct channels for reporting electricity-related problems."
            },

            // Arts and Culture
            new CommunityEvent
            {
                EventId = 19,
                EventName = "Local Arts and Culture Festival",
                Category = "Arts and Culture",
                EventDate = new DateTime(2026, 12, 6),
                Location = "Durban Central",
                Description = "Celebrate local artists, cultural performances, music, and creative talent."
            },
            new CommunityEvent
            {
                EventId = 20,
                EventName = "Community Music Showcase",
                Category = "Arts and Culture",
                EventDate = new DateTime(2027, 1, 30),
                Location = "Umlazi",
                Description = "Enjoy performances by local musicians and emerging community talent."
            },

            // Sports and Recreation
            new CommunityEvent
            {
                EventId = 21,
                EventName = "Community Fun Run",
                Category = "Sports and Recreation",
                EventDate = new DateTime(2026, 11, 15),
                Location = "Durban North",
                Description = "Participate in a community fun run promoting fitness and social participation."
            },
            new CommunityEvent
            {
                EventId = 22,
                EventName = "Youth Football Tournament",
                Category = "Sports and Recreation",
                EventDate = new DateTime(2026, 12, 13),
                Location = "KwaMashu",
                Description = "Support local youth teams competing in a community football tournament."
            },
            new CommunityEvent
            {
                EventId = 23,
                EventName = "Family Recreation Day",
                Category = "Sports and Recreation",
                EventDate = new DateTime(2027, 2, 6),
                Location = "Westville",
                Description = "Enjoy family-friendly outdoor activities and recreational games."
            },

            // Public Announcements
            new CommunityEvent
            {
                EventId = 24,
                EventName = "Municipal Public Participation Meeting",
                Category = "Public Announcement",
                EventDate = new DateTime(2026, 11, 18),
                Location = "Durban",
                Description = "Residents can discuss municipal priorities and provide feedback on proposed community initiatives."
            },
            new CommunityEvent
            {
                EventId = 25,
                EventName = "Community Development Programme Registration",
                Category = "Public Announcement",
                EventDate = new DateTime(2027, 2, 13),
                Location = "Pinetown",
                Description = "Find out about registration requirements and opportunities for upcoming community development programmes."
            }
        };

            // Clear existing data structures before repopulating them.
            eventDictionary.Clear();
            eventsByDate.Clear();

            // Populate the event dictionary and sorted dictionary.
            foreach (CommunityEvent ev in allEvents)
            {
                eventDictionary[ev.EventId] = ev;

                if (!eventsByDate.ContainsKey(ev.EventDate.Date))
                {
                    eventsByDate[ev.EventDate.Date] = new List<CommunityEvent>();
                }

                eventsByDate[ev.EventDate.Date].Add(ev);
            }

            // Populate the Queue with upcoming events in chronological order.
            upcomingEvents.Clear();

            foreach (CommunityEvent ev in allEvents
                .Where(ev => ev.EventDate.Date >= DateTime.Today)
                .OrderBy(ev => ev.EventDate))
            {
                upcomingEvents.Enqueue(ev);
            }

            // Store unique event categories in the HashSet.
            eventCategories.Clear();

            foreach (CommunityEvent ev in allEvents)
            {
                if (!string.IsNullOrWhiteSpace(ev.Category))
                {
                    eventCategories.Add(ev.Category);
                }
            }

            // Populate filters after the HashSet has been filled.
            PopulateFilters();

            // Display all events in chronological order.
            DisplayEvents(GetEventsByDate());

            // Display upcoming events from the Queue.
            DisplayUpcomingEvents();
        }

        // Returns events grouped by date, in chronological order.
        private List<CommunityEvent> GetEventsByDate()
        {
            return eventsByDate
                .SelectMany(group => group.Value)
                .ToList();
        }

        // =========================================================
        // DISPLAY EVENTS AND EVENT DETAILS
        // =========================================================

        // Displays the supplied events in the main events table.
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

        // Handles the View Details button in the main events table.
        private void dataGridView_events_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                dataGridView_events.Columns[e.ColumnIndex].Name != "btnViewDetails")
            {
                return;
            }

            int eventId = Convert.ToInt32(
                dataGridView_events.Rows[e.RowIndex].Cells["EventId"].Value);

            if (eventDictionary.TryGetValue(eventId, out CommunityEvent ev))
            {
                recentlyViewedEvents.Push(ev);

                // Write the most recently viewed event to the Debug Output window.
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

        // Displays upcoming events using the Queue.
        private void DisplayUpcomingEvents()
        {
            lstUpcomingEvents.Items.Clear();

            foreach (CommunityEvent ev in upcomingEvents)
            {
                lstUpcomingEvents.Items.Add(
                    $"{ev.EventDate:dd MMM yyyy}  " +
                    $"{ev.EventName}  {ev.Location}");
            }
        }

        // =========================================================
        // RECOMMENDATIONS
        // =========================================================

        // Records the user's search preference based on the most specific filter.
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

        // Displays recommendations in a table, excluding events already shown
        // in the main results table.
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

            // Get event IDs currently displayed in the main table.
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

            // Display the recommendations in the recommendations table.
            dataGridView_recommendations.DataSource = recommendations;
        }

        // Handles the View Details button in the recommendations table.
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

        // =========================================================
        // NAVIGATION
        // =========================================================

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Hide();
        }
    }
}
