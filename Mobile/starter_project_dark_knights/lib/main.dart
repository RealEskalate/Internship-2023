import 'package:dark_knights/features/example/presentation/screen/onboarding_screen.dart';
import 'package:dark_knights/features/example/presentation/screen/splash_screen.dart';
import 'package:flutter/material.dart';

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
        primarySwatch: Colors.blue,
      ),
      routes: {
        '/main': (context) => const OnboardingScreen(),
      },
      home: const SplashScreen(),
    );
  }
}
