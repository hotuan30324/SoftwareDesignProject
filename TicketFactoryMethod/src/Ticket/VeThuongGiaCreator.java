package Ticket;

public class VeThuongGiaCreator extends VeCreator {

	@Override
	public Ve createVe() {
		return new VeThuongGia();
	}
	
}
