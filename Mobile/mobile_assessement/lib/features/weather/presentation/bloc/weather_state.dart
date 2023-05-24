import 'package:mobile_assessement/features/weather/presentation/bloc/weather_search_status.dart';

import '../../data/model/weather_model.dart';
import '../../domain/entity/weather.dart';

class WeatherState {
  String cityName;
  dynamic weather;
  bool? isFavorite;
  FormSubmittionStatus? formSubmittionStatus;

  WeatherState({
    this.cityName = '',
    this.isFavorite = false,
    this.weather =  '',
    this.formSubmittionStatus = const InititalStatus(),
  });
  WeatherState copyWith({
    String? cityName,
    bool? isFavorite,
    Weather? weather,
    FormSubmittionStatus? formSubmittionStatus,
  }) {
    return WeatherState(
      cityName: cityName ?? this.cityName,
      weather: weather??this.weather,
      isFavorite: isFavorite ?? this.isFavorite,
      formSubmittionStatus: formSubmittionStatus ?? this.formSubmittionStatus,
    );
  }

  List<Object?> get props => [
        cityName,
        isFavorite,
        formSubmittionStatus,
      ];
}
