



public class Calculadora {
	
	public static double soma(String[]args){
		double a = Double.parseDouble(args[0]);
		double b = Double.parseDouble(args[2]);
		return a+b;
	}
	
	public static double subtrai(String[]args){
		double a = Double.parseDouble(args[0]);
		double b = Double.parseDouble(args[2]);
		return a-b;
	}
	
	public static double multiplica(String[]args){
		double a = Double.parseDouble(args[0]);
		double b = Double.parseDouble(args[2]);
		return a*b;
	}
	
	public static double divide(String[]args){
		double a = Double.parseDouble(args[0]);
		double b = Double.parseDouble(args[2]);
		return a/b;
	}	
	
	public static void main(String []args){
	    System.out.println("Laborat�rio 1 de Programa��o Orientada a Objetos  ");
        System.out.println("Alunos: �talo Rodrigues Alves e Ryan Lemes Bezerra");
        System.out.println("Sistemas de Informa��o 2� Per�odo - Manh�");

		double resultado;
		
		 if(args[1].equals(String.valueOf('+')))
         {
             resultado = soma(args);
             System.out.println("R: " + resultado);
         }

         else if (args[1].equals(String.valueOf('-')))
         {
             resultado = subtrai(args);
             System.out.println("R: " + resultado);
         }

         else if ((args[1].equals(String.valueOf("*"))) || (args[1].equals(String.valueOf('x'))) || (args[1].equals(String.valueOf('X'))))
         {
             resultado = multiplica(args);
             System.out.println("R: " + resultado);
         }

         else if (args[1].equals(String.valueOf('/')))
         {
             resultado = divide(args);
             System.out.println("R: " + resultado);
         }
         else System.out.println("Opera��o inv�lida");
		    
     }
	}
