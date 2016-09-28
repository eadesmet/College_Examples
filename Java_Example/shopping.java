import java.util.Scanner;
import java.util.Random;
import java.text.NumberFormat;

public class JavaApplication3 {

   static boolean blnContinueShopping = true;
   static boolean blnContinueOrder = true;
   static boolean blnDiscountCorrect = false;
   static String[] items = {"iPod Classic",
              "iPod Classic case",
              "iPod/iPhone charger",
              "earphone",
              "iPhone4"};
   static int[] itemsPrices = {200, 15, 40, 20, 300};
   static int[] itemsInCart = {0, 0, 0, 0, 0};
   static String[] discountQuestions = {"When was the first iPod released?",
              "What model did the iPod nano replace?",
              "Has any company other than Apple ever sold the iPod?",
              "When was the first iPhone released?"};
   static String[] questionsAnswers = {"October 2001",
              "iPod mini",
              "yes",
              "June 2007"};
   static Scanner input = new Scanner(System.in);

   public static boolean continueShopping() {
       int answer = 0;
       String tempString;
       //Scanner input = new Scanner(System.in);
       boolean continueAsking = true;
       while (continueAsking) {
          System.out.println("Continue shopping? (1 = yes, 2 = no)");
          tempString = input.nextLine();
          if ("1".equals(tempString)) {
             //yes to continue shopping
              continueAsking = false;
              answer = 1;
          }
           else if ("2".equals(tempString)) {
              //no to stop shopping
              continueAsking = false;
              answer = 2;
           }
           else {
              //answer 0 for any other answer to loop question again
              continueAsking = true;
              answer = 0;
           }
       }

       if (answer == 1)
              return true;
          else
              return false;

   }

   public static void order() {
      int selectedInt = 0;
      //Scanner input = new Scanner(System.in);
      System.out.println("Available Items:");

      for (int i = 1; i < 6; i++) {

          System.out.print("     " + i + ") " + items[i - 1]);// + items[i]);
          System.out.println("     $" + itemsPrices[i - 1] + " each");
      }
      System.out.print("Selected (any other number to check out): ");
      selectedInt = Integer.valueOf(input.nextLine()) - 1;
      //IF 1-5!
      if ((0 <= selectedInt) && (selectedInt <= 4)) {
          System.out.println("Current Order: " + itemsInCart[selectedInt]
                  + " " + items[selectedInt]);
          System.out.println("Please enter how many: ");
          itemsInCart[selectedInt] += Integer.valueOf(input.nextLine());
          System.out.println("Order updated to " + itemsInCart[selectedInt]
                  + " " + items[selectedInt]);
          //continue order stays true
      }
      else
          blnContinueOrder = false;

   }

   public static boolean question() {
       Random r = new Random();
       int intRandom = r.nextInt(3) + 1;
       System.out.println(discountQuestions[intRandom]);
       String answer = input.nextLine();
       if (answer.equals(questionsAnswers[intRandom])) {
           System.out.println("Correct. You get a 10% discount.");
           return true;
       }
       else
           return false;
   }

   public static int AskShipping() {
       //shipping 1 or 2 (also calculate how much shipping is)
       int shippingOption = 0;
       String tempString;
       boolean continueAsking = true;
       while (continueAsking) {
          System.out.println("Please choose your shipping option:");
          System.out.println("    1) Standard Shipping");
          System.out.println("    2) Express Shipping");
          tempString = input.nextLine();
          if ("1".equals(tempString)) {
              continueAsking = false;
              shippingOption = 1;
          }
           else if ("2".equals(tempString)) {
              continueAsking = false;
              shippingOption = 2;
           }
           else {
              continueAsking = true;
              shippingOption = 0;
           }
       }
       return shippingOption;
   }

   public static void Checkout(int shippingOption) {
       int subtotal = 0;
       NumberFormat fmt = NumberFormat.getCurrencyInstance();
       System.out.println("Here are you order details");
       for (int i = 0; i <= 4; i++) {
           if (itemsInCart[i] > 0) {
               System.out.printf("%-40s", "    " + itemsInCart[i] + " " + items[i] + "at " + fmt.format(itemsPrices[i]) + " each:");
               System.out.printf("%10s\n", fmt.format(itemsPrices[i] * itemsInCart[i]));
               subtotal += itemsPrices[i] * itemsInCart[i];
           }
       }
       //order details
       System.out.printf("%50s\n", "--------");
       System.out.printf("%-40s", "    Subtotal:");
       System.out.printf("%10s\n", fmt.format(subtotal));
       if (blnDiscountCorrect) {
           System.out.printf("%-40s", "    10% Discount:");
           double test = .1 * subtotal; //for formatting purposes
           System.out.printf("%10s\n", fmt.format(test));
       }
       int shipping = 0;
       if (shippingOption == 1) { //regular shipping
           if (subtotal > 100) {
               int temp = subtotal - 100;
               temp = temp / 50;
               shipping = ((temp * 2) +5);
               System.out.printf("%-40s", "    Regular Shipping:");
               System.out.printf("%10s\n", fmt.format(shipping));
           }
           else { //if shipping option 1 and less than 100
               shipping = 5;
               System.out.printf("%-40s %10s\n", "    Regular Shipping: ", fmt.format(shipping));
           }
       }

       if (shippingOption == 2) {
           if (subtotal > 100) {
               int temp2 = subtotal - 100;
               temp2 = temp2 / 50;
               shipping = ((temp2 * 5) + 10);
               System.out.printf("%-40s", "    Express Shipping:");
               System.out.printf("%10s\n", fmt.format(shipping));
           }
           else {
               shipping = 10;
               System.out.printf("%-40s", "    Express Shipping:", fmt.format(shipping));
           }
       }

       System.out.printf("%50s\n", "---------");
       System.out.printf("%-40s", "    Total:");
       if (blnDiscountCorrect) {
           double value = subtotal - (subtotal * .1) + shipping; //for formatting
           System.out.printf("%10s\n", fmt.format(value));
       }
       else {
           double value2 = subtotal + shipping; //for formatting
           System.out.printf("%10s\n", fmt.format(value2));
       }
   }

   public static void CreditCard() {
       System.out.println("Please enter your credit card number:");
       String cardNumber = input.nextLine();
       while (cardNumber.length() != 16) {
           System.out.println("Invalid number");
           System.out.println("Please enter your credit card number:");
           cardNumber = input.nextLine();
       }


   }

    //***********************************************************
    public static void main(String[] args) {
        System.out.println("Welcome to Eric DeSmet's iPox Store!");
        blnContinueShopping = continueShopping();
        while (blnContinueShopping) {
            //if continue shopping true..
            while (blnContinueOrder) { //while answer is 1-5
                order();
            }
            //finalize order
            blnDiscountCorrect = question();
            int shippingOption = AskShipping();
            Checkout(shippingOption);
            CreditCard();
            System.out.println("Thank you for your order!");
            System.out.println("=========================================");
            //creditcard here also
            //ask continue shopping?
            blnContinueShopping = continueShopping();
            if (blnContinueShopping == true)
                blnContinueOrder = true;
            //if no to continue shopping; goodbye and stop application
        }

        System.out.println("Thank you! Goodbye!");
    }

}