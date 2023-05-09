import 'package:dark_knights/features/article/presentation/screen/article_reading_page.dart';

import 'features/Authentication/presentation/screen/login_page.dart';
import 'features/article/presentation/screen/write_article_page.dart';
import 'features/feeds/presentation/screen/home_page.dart';
import 'features/splash_screen/presentation/screen/splash_screen.dart';
import 'package:flutter/material.dart';

import 'features/user_profile/presentation/screen/profile_page.dart';

void main() {
  runApp(MyApp());
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
      home: const LoginPage(),
    );
  }
}

