package Ticket;

public class VeThuong implements Ve {
	private static int serial = 1;
	private int maVe;
	private int maChuyenBay;
	private String loaiVe;
	private double giaVe;
	
	public VeThuong() {
		maVe = serial;
		maChuyenBay = serial;
		loaiVe = "Vé thường";
		giaVe = 500000;
		serial++;
	}
	
	@Override
	public void hienThiThongTinVe() {
		System.out.println("Mã vé: " + this.maVe);
		System.out.println("Mã chuyến bay: " + this.maChuyenBay);
		System.out.println("Loại vé: " + this.loaiVe);
		System.out.println("Giá vé: " + this.giaVe);
	}

}
