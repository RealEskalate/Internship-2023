import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weatherify/domain/use_case/weather_use_case.dart';
import 'package:mobile_assessement/features/weatherify/presentation/screen/welcome_page.dart';

import 'features/weatherify/presentation/bloc/bloc/weather_bloc.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      home: BlocProvider<WeatherBloc>(
        create: (context) =>WeatherBloc(GetWeatherForCity as GetWeatherForCity),
        child: WelcomePage(),
      ),
    );
  }
}
