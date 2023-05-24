import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/bloc/weather_bloc_bloc.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/onboarding.dart';
import 'package:mobile_assessement/injection/injection.dart';
import 'injection/injection.dart' as di;

void main() async{
  di.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<WeatherBloc>(
          create: (_) => sl<WeatherBloc>(),
        ),
        // Add more BlocProviders here if needed
      ],
      child: MaterialApp(
        title: 'Flutter Demo',
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        home: OnboardingPage(),
      ),
    );
  }
}

