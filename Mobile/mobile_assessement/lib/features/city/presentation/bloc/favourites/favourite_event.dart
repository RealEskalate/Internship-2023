abstract class FavoritesEvent {}

class AddFavoriteCityEvent extends FavoritesEvent {
  final String cityName;
  AddFavoriteCityEvent({required this.cityName});
}

class RemoveFavoriteCityEvent extends FavoritesEvent {
  final String cityName;
  RemoveFavoriteCityEvent({required this.cityName});
}
