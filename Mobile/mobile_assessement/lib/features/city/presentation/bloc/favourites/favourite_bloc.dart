import 'package:flutter_bloc/flutter_bloc.dart';

import 'favourite_event.dart';
import 'favourite_state.dart';

class FavoritesBloc extends Bloc<FavoritesEvent, FavoritesState> {
  List<String> _favoriteCities = [];

  FavoritesBloc() : super(FavoritesInitialState()) {
    on<AddFavoriteCityEvent>((
      AddFavoriteCityEvent event,
      Emitter<FavoritesState> emit,
    ) {
      _favoriteCities.add(event.cityName);
      emit(FavoritesUpdatedState(favoriteCities: _favoriteCities));
    });

    on<RemoveFavoriteCityEvent>((
      RemoveFavoriteCityEvent event,
      Emitter<FavoritesState> emit,
    ) {
      _favoriteCities.remove(event.cityName);
      emit(FavoritesUpdatedState(favoriteCities: _favoriteCities));
    });
  }
}
