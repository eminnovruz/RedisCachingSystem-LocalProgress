using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Services;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCaching _cache;

        public Form1()
        {
            InitializeComponent();

            _cache = new RedisCachingService(DbService.GetConnectionString());
            _context = new AppDbContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                LoadUsersFromDatabase();
            }
        }

        private void LoadUsersFromDatabase()
        {
            listBox1.Items.Clear();
            foreach (var user in _context.Users)
            {
                listBox1.Items.Add($"{user.Name}\t{user.Surname}\t{user.Email}\t{user.Age}\t{user.PhoneNumber}");
            }
            listBox2.Items.Add("Users Loaded from <DATABASE>");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FetchFaculties();
        }

        private async void FetchFaculties()
        {
            if (await _cache.CheckIfExist("Faculties"))
            {
                await LoadFacultiesFromCache();
            }
            else
            {
                await LoadFacultiesFromDatabase();
            }
        }

        private async Task LoadFacultiesFromCache()
        {
            var faculties = await _cache.GetCacheData<List<Faculty>>("Faculties");
            PopulateFacultyComboBox(faculties);
            listBox2.Items.Add("Faculties Loaded from <Cache>");
        }

        private async Task LoadFacultiesFromDatabase()
        {
            var faculties = await _context.Faculties.ToListAsync();
            PopulateFacultyComboBox(faculties);

            await _cache.SetCacheData("Faculties", faculties, DateTimeOffset.UtcNow.AddSeconds(200));

            listBox2.Items.Add("Faculties cached...");
            listBox2.Items.Add("Faculties Loaded from <DATABASE>");
        }

        private void PopulateFacultyComboBox(IEnumerable<Faculty> faculties)
        {
            comboBox2.Items.Clear();
            foreach (var faculty in faculties)
            {
                comboBox2.Items.Add(faculty.Name);
            }
        }
    }
}