import 'package:flutter/material.dart';
import 'features/onboarding/presentation/screen/onboarding_screen.dart';
import 'features/feed/presentation/screen/home_page.dart';

import 'features/login_page/Presentation/screen/login_page.dart';
import 'features/example/presentation/screen/onboarding_1_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Onboarding Screen 1',
      debugShowCheckedModeBanner: false,
      home: OnBoardingScreen1(),
    );
  }
}
