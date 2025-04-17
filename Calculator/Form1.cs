using System.Data;
namespace Calculator;

public partial class Form1 : Form
{
    private string currentCalculation = ""; //What the current calculation for the cal is
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        
    }
    
    /*
     * object sender means that an object, which is the sender, sent an event to the
     * recipient. In this case, the button is the sender and the form is the recipient.
     * The button is clicked, which then sends an event to the form.
     * This method will display the text of the button into the textbox when the
     * button is clicked. 
     */
    private void button_click(object sender, EventArgs e)
    {
        currentCalculation += (sender as Button).Text;
        textBox.Text = currentCalculation;
    }

    /*
     * This method will calculate the expression in the textbox when the
     * equal button is clicked. In this method, we will use System.Data and the
     * Datatable and Compute function to calculate the expression. We make it into
     * a string first, then use the methods to calculate the expressions. The result
     * will then be made into a string again, since it will not be a string when
     * the compute happens. If there is an error, it will catch it and then
     * return the current calculation back to empty.
     */
    private void button_Equals_click(object sender, EventArgs e)
    {
        string formattedCalculation = currentCalculation.ToString();
        try
        {
            textBox.Text = new DataTable().Compute(formattedCalculation, null).ToString();
            currentCalculation = textBox.Text;
        }
        catch (Exception ex)
        {
            textBox.Text = "There is an error";
            currentCalculation = "";
        }
    }

    //When the  all clear button is pressed, it will clear everything
    private void button_AllClear_clicked(object sender, EventArgs e)
    {
        textBox.Text = "";
        currentCalculation = "";
    }
    
    //When the clear button is pressed, it will clear one value from it
    private void button_Clear_clicked(object sender, EventArgs e)
    {
        if (currentCalculation.Length > 0)
        {
            currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
        }
        textBox.Text = currentCalculation;
    }
}