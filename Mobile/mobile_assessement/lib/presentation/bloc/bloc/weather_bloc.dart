import 'package:bloc/bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/data/datasources/weather_remote_datasource.dart';
import 'package:mobile_assessement/domain/usecases/get_weather_data.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_event.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_state.dart';

import '../../../core/error_handle/failure.dart';
import '../../../domain/Entity/weather_entity.dart';


class WeatherBloc extends Bloc<WeatherEvent ,WeatherDataState> {

  final GetWeatherData getWeather;

  WeatherBloc(this.getWeather
  ) : super(WeatherDataInitial()) {
    on<LoadWeatherEvent>(_loadUser);
  }

 
  void _loadUser( LoadWeatherEvent  event, Emitter<WeatherDataState> emit) async {
    emit(WeatherDataLoading());
    final result = await getWeather(event.city) ;
    emit(_loadingSuccessOrFailure(result as Either<Failure, WeatherEntity>));
  }



  _loadingSuccessOrFailure(Either<Failure, WeatherEntity> data) {
    return data.fold((failure) => WeatherDataFailure(error: failure),
        (success) => WeatherDataLoaded(weather: success));
  }
}
