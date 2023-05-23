import 'package:mobile_assessement/features/weather/presentation/bloc/weather_search_status.dart';

class WeatherState {
  String cityName;
  bool isFavorite;
  FormSubmittionStatus formSubmittionStatus;

  WeatherState({
    this.cityName = '',
    this.isFavorite = false,
    this.formSubmittionStatus = const InititalStatus(),
  });
  WeatherState copyWith({
    String? cityName,
    bool? isFavorite,
    FormSubmittionStatus? formSubmittionStatus,
  }) {
    return WeatherState(
      cityName: cityName ?? this.cityName,
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
