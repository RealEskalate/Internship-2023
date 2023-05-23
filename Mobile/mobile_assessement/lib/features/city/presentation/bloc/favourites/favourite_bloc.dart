import 'package:flutter_bloc/flutter_bloc.dart';

import 'favourite_event.dart';
import 'favourite_state.dart';

class FavouritesBloc extends Bloc<FavouritesEvent, FavouritesState> {
  final AddCityToFavourites addCityToFavourites;
  final RemoveCityFromFavourites removeCityFromFavourites;

  FavouritesBloc({
    required this.addCityToFavourites,
    required this.removeCityFromFavourites,
  }) : super(FavouritesState.initial()) {
    on<AddCityToFavourites>((event, emit) async {
      emit(FavouritesState(cities: [...state.cities, event.city]));
    });

    on<RemoveCityFromFavourites>((event, emit) async {
      emit(FavouritesState(
          cities: state.cities
              .where((city) => city.cityName != event.city.cityName)
              .toList()));
    });
  }
}
