import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/weatherify/domain/entity/weather_entity.dart';
import 'package:mobile_assessement/features/weatherify/domain/use_case/weather_use_case.dart';

part 'weather_event.dart';
part 'weather_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {
  final GetWeatherForCity getWeatherForCity;
  
  WeatherBloc(this.getWeatherForCity) : super(WeatherInitial()) {
    on<WeatherEvent>((event, emit) {
      // TODO: implement event handler
      
    });
    on<GetWeatherEvent>((event, emit) async {
      emit(WeatherLoading as WeatherState);
      await getWeatherForCity(event.city);

      emit(WeatherLoaded as WeatherState);


    });
  }
}
