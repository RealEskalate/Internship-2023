import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failures.dart';
import '../../domain/entities/weather_detail_domain.dart';
import '../../domain/usecases/get_weather_detail.dart';

part 'weather_event.dart';
part 'weather_state.dart';

class WeatherBloc extends Bloc<WeatherEvent, WeatherState> {

  GetWeather getWeather; 
  
  WeatherBloc({required this.getWeather}) : super(WeatherInitial()) {
    on<WeatherEvent>((event, emit) {

    });

    on<FetchWeatherEvent>((event, emit) async {
      emit(WeatherLoading());

      final failureOrWeather = await getWeather(event.city);
            
      emit(_fetchOrFailure(failureOrWeather));
        
    });
  }


}


 _fetchOrFailure(both) {
    return both.fold(
      (failure) => ServerFailure(),
      (temp) => WeatherSuccess(temperatureData: temp),
    );
 }