abstract class FavoritesState {}

class FavoritesInitialState extends FavoritesState {}

class FavoritesUpdatedState extends FavoritesState {
  final List<String> favoriteCities;
  FavoritesUpdatedState({required this.favoriteCities});
}
