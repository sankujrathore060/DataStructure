using System;
public class ArithmeticOperation{

	public static bool NumberDivideByDeviderOrNot(string number, int devider){
		int sumOfEvenPlaceNo = 0, sumOfOddPlaceNo = 0;
		for(int index = 0; index < number.Length; index++){
			if((index%2)==0){
				sumOfEvenPlaceNo+= (number[index] - '0');
			}
			else {
				sumOfOddPlaceNo+= (number[index] - '0');
			}
		}
		return ((sumOfEvenPlaceNo - sumOfOddPlaceNo)%11 == 0);
	}

	public static void Subtraction(string num1, string num2){
		int carry = 0;
		int diffrenceOfLength = num1.Length - num2.Length; 
		
		string finalResult = "", innerResult = "";
		for(int num = num2.Length - 1; num >=0 ; num--){
			string currentA = num1[diffrenceOfLength + num].ToString(); 
			if(carry ==1 &&  num1[diffrenceOfLength + num]== '0'){
				currentA = "9";
			}
			else if(carry ==1 &&  num1[diffrenceOfLength + num] != '0'){
				currentA = (num1[diffrenceOfLength + num] - '1').ToString();
				carry = 0;
			}
			
			if(carry ==0 &&  num1[diffrenceOfLength + num] <  num2[num]){
				currentA =  "1" + currentA;
				carry = 1;
			}
			innerResult = (Int32.Parse(currentA) - Int32.Parse(num2[num].ToString())).ToString() + innerResult;
		}
		while(carry == 1){
			diffrenceOfLength--;
			string currentA = num1[diffrenceOfLength].ToString(); 
			if(carry ==1 &&  num1[diffrenceOfLength] == '0'){
				currentA = "9";
			}
			else if(carry ==1 &&  num1[diffrenceOfLength] != '0'){
				currentA = ( num1[diffrenceOfLength] - '1').ToString();
				carry = 0;
			}
			innerResult = (Int32.Parse(currentA)).ToString() + innerResult;
		}
		finalResult+= innerResult;
		Console.WriteLine(finalResult);
	}

	public static void Main(string[] args){
		string no = "1234567589333892";
		Console.WriteLine(NumberDivideByDeviderOrNot(no, 11));
		Subtraction("85", "25");
	}
}