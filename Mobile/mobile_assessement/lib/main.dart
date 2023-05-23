import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/screens/cities_page.dart';

import 'core/utils/colors.dart';
import 'features/weather/presentation/bloc/weather_bloc.dart';
import 'features/weather/presentation/screens/city_detail.dart';
import 'injection.dart' as injection;

void main() {
  injection.init();
  runApp(MultiBlocProvider(providers: [
    BlocProvider<WeatherBloc>(
      create: (_) => injection.sl<WeatherBloc>(),
    ),
  ], child: const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
          primaryColor: primaryColor,
          scaffoldBackgroundColor: scaffoldBackground),
      title: 'Flutter Demo',
      debugShowCheckedModeBanner: false,
      home: CitiesList(),
    );
  }
}
