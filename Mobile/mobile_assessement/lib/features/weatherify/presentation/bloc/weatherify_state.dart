part of 'weatherify_bloc.dart';

abstract class WeatherifyState extends Equatable {
  final Weather weather;
  const WeatherifyState({required this.weather});

  @override
  List<Object> get props => [];
}

class WeatherInitial extends WeatherifyState {
  WeatherInitial()
      : super(
            weather: Weather(
                temperature: "",
                cityName: "",
                date: "",
                weatherDesc: "",
                image: ""));
}

class WeatherLoading extends WeatherifyState {
  WeatherLoading()
      : super(
            weather: Weather(
                temperature: "",
                cityName: "",
                date: "",
                weatherDesc: "",
                image: ""));
}

class WeatherLoaded extends WeatherifyState {
  WeatherLoaded({required super.weather});
}

class WeatherFailed extends WeatherifyState {
  final Failure failure;
  WeatherFailed({required this.failure})
      : super(
            weather: Weather(
                temperature: "",
                cityName: "",
                date: "",
                weatherDesc: "",
                image: ""));
}
