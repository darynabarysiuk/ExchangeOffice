using Aspose.Pdf;
using Aspose.Pdf.Text;
using ExchangeOffice.Entities;
using ExchangeOffice.IServices;

namespace ExchangeOffice.Services
{
    public class CheckService : ICheckService
    {
        public Document GenerateCheck(OperationHistory operationHistory)
        {
            Document document = new Document();
            document.PageInfo.Height = 300;
            document.PageInfo.Width = 300;
            Page page = document.Pages.Add();
            page.Paragraphs.Add(new TextFragment("Чек"));
            page.Paragraphs.Add(new TextFragment("Перевод в размере " + operationHistory.Value));
            page.Paragraphs.Add(new TextFragment("Перевод с " + operationHistory.CurrencyRate.CurrencyFrom.Name));
            page.Paragraphs.Add(new TextFragment("Перевод на " + operationHistory.CurrencyRate.CurrencyTo.Name));
            page.Paragraphs.Add(new TextFragment("По курсу: " + operationHistory.CurrencyRate.Value));
            page.Paragraphs.Add(new TextFragment("Операция была проведена во время: " + operationHistory.DateTime));
            return document;
        }
    }
}
