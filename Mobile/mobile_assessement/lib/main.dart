import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/bloc/weather_bloc.dart';
import 'features/weather/presentation/screens/detail.dart';
import 'features/weather/presentation/screens/getstarted.dart';
import 'features/weather/presentation/screens/home.dart';
import 'dependency_injection.dart' as di;
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.weatherInjectionInit();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  static GetIt get sl => GetIt.instance;
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return BlocProvider<WeatherBloc>(
        create: (_) => di.sl<WeatherBloc>(),
        child: MaterialApp(
          title: 'Flutter Demo',
          debugShowCheckedModeBanner: false,
          theme: ThemeData(
            primarySwatch: Colors.blue,
          ),
          home: const GetStarted(),
        ));
  }
}
