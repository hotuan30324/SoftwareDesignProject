package Ticket;

public class VeThuongGia implements Ve {
	private static int serial = 1;
	private int maVe;
	private int maChuyenBay;
	private String loaiVe;
	private double giaVe;
	
	public VeThuongGia() {
		maVe = serial;
		maChuyenBay = serial;
		loaiVe = "Vé thương gia";
		giaVe = 1000000;
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
