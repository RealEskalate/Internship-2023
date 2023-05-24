import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/presentation/screen/detail_page.dart';
import 'package:mobile_assessement/features/presentation/screen/home_page.dart';
import 'package:mobile_assessement/injection.dart';
import 'features/presentation/bloc/city_weather_bloc.dart';
import 'injection.dart' as dependency_injection;
import 'features/presentation/screen/spilash_page.dart';

void main() {
  dependency_injection.init();
  runApp(
    MultiBlocProvider(
      providers: [
        BlocProvider<CityWeatherBloc>(
          create: (_) => serviceLocator<CityWeatherBloc>(),
        )
      ],
      child: DetailPage(),
    ),
  );
}
