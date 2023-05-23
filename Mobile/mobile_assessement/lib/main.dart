import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/screens/get_start/wecome.dart';
// import 'package:dartsmiths/injection/injection.dart'  as injection;

void main() {
  // injection.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: WeatherPage(),
    );
  }
}
