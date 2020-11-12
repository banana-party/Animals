/*Достаточно было оставить какой-нибудь один из этих методов либо Write либо WriteLine
 иначе это нарушает принцип разделения интерфейсов и не во всех платформах возможно сделать обе реализации*/
namespace Animals.Core.Interfaces
{
	public interface INotificationService
	{
		void Write(string text);
	}
}
