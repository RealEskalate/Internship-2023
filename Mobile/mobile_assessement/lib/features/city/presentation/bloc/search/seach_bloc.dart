import 'package:flutter_bloc/flutter_bloc.dart';

import '../../../domain/usecases/get_city_weather_usecase.dart';
import 'search_event.dart';
import 'search_state.dart';

class SearchBloc extends Bloc<SearchEvent, SearchState> {
  final GetCityWeatherUseCase _getCityWeather;

  SearchBloc({required GetCityWeatherUseCase getCityWeather})
      : _getCityWeather = getCityWeather,
        super(SearchInitialState()) {
    on<SearchCityEvent>((
      SearchCityEvent event,
      Emitter<SearchState> emit,
    ) async {
      emit(SearchLoadingState());

      final result = await _getCityWeather.call(event.cityName);
      emit(SearchSuccessState(city: result));

      // result.fold(
      //   (error) => emit(SearchFailureState(error: error.toString())),
      //   (city) => emit(SearchSuccessState(city: city)),
      // );
    });
  }
}
