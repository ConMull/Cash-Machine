using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder

{

    String cardNumber;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance) 
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.balance = balance;
    }

    public String getNumber()
    {
        return cardNumber;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNumber(String newCardNumber)
    {
        cardNumber = newCardNumber;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for depositing. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser) 
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // check if the user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficiant balance");
            }
            else 
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for withdrawing." + " Your new balance is: " + currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("", 1234, "Erling", "Haaland", 150.31));
        cardHolders.Add(new cardHolder("93018573954183928742", 4321, "Phil", "Foden", 321.13));
        cardHolders.Add(new cardHolder("81741823942184218498", 9999, "Kevin", "De Bruyne", 851.84));
        cardHolders.Add(new cardHolder("91834509832847628129", 2468, "Bernardo", "Silva", 54.27));
        cardHolders.Add(new cardHolder("48310843180413451802", 4826, "Riyad", "Mahrez", 54.27));

        // Prompt User
        Console.WriteLine("Welcome to CashMachine");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNumber ="";
        cardHolder currentUser;

        while(true)
        {
            try{
                debitCardNumber = Console.ReadLine();
                // check against our database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                if(currentUser != null) { break; }
                else {Console.WriteLine("Card not recognsised. Please try again"); }
            }
            catch {Console.WriteLine("Card not recognsised. Please try again");}
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while(true)
        {
            try{
                userPin = int.Parse(Console.ReadLine());
                // check against our database
                if(currentUser.getPin() == userPin) { break; }
                else {Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch {Console.WriteLine("Incorrect pin. Please try again");}
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do 
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) {deposit(currentUser);}
            else if(option ==2) {withdraw(currentUser);}
            else if(option == 3) {balance(currentUser);}
            else if(option == 4) {break;}
            else {option = 0;}
        }
        while(option != 4);
        {
            Console.WriteLine("Thank you! Have a nice day");
        }
    }

}
