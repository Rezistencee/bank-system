using System.IO;
using System.Security.Cryptography.X509Certificates;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using BankSystem.Models.Structures;

namespace BankSystem.Services;

public static class PDFGenerator
{
    public static void GenerateTransactionFile(DetailTransaction transaction)
    {
        Document document = new Document();
        Page page = document.Pages.Add();
        
        Aspose.Pdf.Image image = new Aspose.Pdf.Image();
        image.File = @"D:\1\Desktop\photos\bank_logo.png";
        image.FixHeight = 96;
        image.FixWidth = 96;
        image.HorizontalAlignment = HorizontalAlignment.Left;
        image.Margin = new MarginInfo { Top = 20, Bottom = 20, Left = 20, Right = 20 };
        
        page.Paragraphs.Add(image);
        
        TextFragment header = new TextFragment("Transaction receipt");
        header.TextState.Font = FontRepository.FindFont("Times New Roman");
        header.TextState.FontSize = 24;
        header.HorizontalAlignment = HorizontalAlignment.Center;
        header.Margin = new MarginInfo() { Bottom = 10 };
        
        page.Paragraphs.Add(header);

        TextState commonTextState = new TextState
        {
            Font = FontRepository.FindFont("Times New Roman"),
            FontSize = 16,
            CharacterSpacing = 0.6f
        };
        
        TextFragment sender = new TextFragment($"Відправник: {transaction.Sender}");
        sender.TextState.ApplyChangesFrom(commonTextState);
        
        TextFragment senderBank = new TextFragment($"Банк відправника: {transaction.SenderBank}");
        senderBank.TextState.ApplyChangesFrom(commonTextState);
        
        TextFragment senderIBAN = new TextFragment($"Рахунок відправника: {transaction.SenderIBAN}");
        senderIBAN.TextState.ApplyChangesFrom(commonTextState);
        senderIBAN.Margin = new MarginInfo() { Bottom = 7.5d };
        
        TextFragment receiver = new TextFragment($"Отримувач: {transaction.Receiver}");
        receiver.TextState.ApplyChangesFrom(commonTextState);
        
        TextFragment receiverBank = new TextFragment($"Банк отримувача: {transaction.ReceiverBank}");
        receiverBank.TextState.ApplyChangesFrom(commonTextState);
        
        TextFragment receiverIBAN = new TextFragment($"Рахунок отримувача: {transaction.ReceiverIBAN}");
        receiverIBAN.TextState.ApplyChangesFrom(commonTextState);
        receiverIBAN.Margin = new MarginInfo() { Bottom = 7.5d };
        
        TextFragment amount = new TextFragment($"Сума: {transaction.Amount:C}");
        amount.TextState.ApplyChangesFrom(commonTextState);
        
        TextFragment description = new TextFragment($"Коментар: {transaction.Description}");
        description.TextState.ApplyChangesFrom(commonTextState);
        description.Margin = new MarginInfo() { Top = 7.5d };
        
        page.Paragraphs.Add(sender);
        page.Paragraphs.Add(senderBank);
        page.Paragraphs.Add(senderIBAN);
        
        page.Paragraphs.Add(receiver);
        page.Paragraphs.Add(receiverBank);
        page.Paragraphs.Add(receiverIBAN);
        
        page.Paragraphs.Add(amount);
        page.Paragraphs.Add(description);
        
        SavePdfWithDialog(document);
    }

    private static async void SavePdfWithDialog(Document document)
    {
        var dialog = new SaveFileDialog();
        dialog.Filters.Add(new FileDialogFilter() {Name = "PDF", Extensions = {"pdf"}});
        
        var result = await dialog.ShowAsync(new Window());
        
        if (result != null)
        {
            document.Save(result);
        }
    }
}