import 'package:equatable/equatable.dart';

class Weather extends Equatable {
  final String date;
  final String maxTempC;
  final String minTempC;
  final String avgTempC;
  final String url;

  const Weather({
    required this.date,
    required this.maxTempC,
    required this.minTempC,
    required this.avgTempC,
    required this.url,
  });

  @override
  List<Object?> get props => [date, maxTempC, minTempC, avgTempC];
}
