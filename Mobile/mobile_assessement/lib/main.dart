import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/splash_screen.dart';
import 'package:mobile_assessement/injection.dart'  as injection;

import 'features/weather/presentation/bloc/weather_bloc.dart';

void main() async{
  await injection.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
        providers: [
          BlocProvider<WeatherBloc>(
            create: (context) => injection.sl<WeatherBloc>()),
        ],
        child: MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        
        primarySwatch: Colors.blue,
      ),
      home: const SplashScreen(),
        ));
   
  }
}
