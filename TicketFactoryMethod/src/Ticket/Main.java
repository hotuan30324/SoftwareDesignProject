package Ticket;

public class Main {
	public static void main(String[] args) {
		//Tạo đối tượng VeThuongCreator
		VeThuongCreator veThuongCreator = new VeThuongCreator();
		//Tạo đối tượng VeThuongGiaCreator
		VeThuongGiaCreator veThuongGiaCreator = new VeThuongGiaCreator();
		
		//Tạo đối tượng vé thường
		Ve ve1 = veThuongCreator.createVe();
		//Tạo đối tượng vé thương gia
		Ve ve2 = veThuongGiaCreator.createVe();
		Ve ve3 = veThuongCreator.createVe();
		
		//Hiển thị thông tin của vé 1
		System.out.println("Thông tin vé 1: ");
		ve1.hienThiThongTinVe();
		//Hiển thị thông tin của vé 2
		System.out.println("Thông tin vé 2: ");
		ve2.hienThiThongTinVe();
	}
}
