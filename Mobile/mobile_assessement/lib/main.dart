import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/detail_page.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/getstarted_page.dart';

import 'features/weather/presentation/screen/search_page.dart';

void main() {
  // injection.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      // home: DetailPage(cityName: 'Addis', isFavorite: true),
      // home: SearchCityPage(),
      home:  GetStartedPage(),
    );
  }
}
