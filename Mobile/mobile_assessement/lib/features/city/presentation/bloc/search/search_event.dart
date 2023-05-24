abstract class SearchEvent {}

class SearchCityEvent extends SearchEvent {
  final String cityName;
  SearchCityEvent({required this.cityName});
}
