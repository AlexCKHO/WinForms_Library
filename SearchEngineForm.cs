using EI_Task.Models;
using EI_Task.Models.DTO;
using EI_Task.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EI_Task
{
    public partial class SearchEngineForm : Form
    {
        private readonly IBookManagerService _bookManagerService;
        private List<BookSearchResultDTO> _listOfDTO = new List<BookSearchResultDTO>();
        public SearchEngineForm(IBookManagerService bookManagerService)
        {
            _bookManagerService = bookManagerService;
            InitializeComponent();

        }

        private async void SearchEngineForm_Load(object sender, EventArgs e)
        {
            await getEveryDTO();
            setSearchItemList();
        }


        private void MainPageBotton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setSearchItemList()
        {
            searchItemList.DataSource = _listOfDTO;
        }

        private async Task getEveryDTO()
        {
            _listOfDTO.Clear();
            _listOfDTO = await _bookManagerService.GetListOfBookSearchResultDTO();
        }

        private async Task<bool> getDTOByKeyword(string keyword)
        {
            
            var result = await _bookManagerService.GetListOfBookSearchResultDTO(keyword);
            if(result.Count == 0)
            {
                return false;
            } else
            {
                _listOfDTO.Clear();
                _listOfDTO = result.ToList();
                return true;
            }

        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            //input -> string, string to trim
            string keyword = SearchTextBox.Text.Trim();
            if (String.IsNullOrEmpty(keyword))
            {
                await getEveryDTO();
                setSearchItemList();
            }
            else
            {

                var result = await getDTOByKeyword(keyword);
                if (result)
                {
                    setSearchItemList();
                }
            }

        }
    }
}
