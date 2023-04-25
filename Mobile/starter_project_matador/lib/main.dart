import 'package:flutter/material.dart';
import 'features/example/presentation/screen/onboarding_screen_2.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Onboarding Screen 2',
      debugShowCheckedModeBanner: false,
      home: OnBoardingScreen2(),
    );
  }
}
