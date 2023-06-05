import 'package:flutter/material.dart';

import '../widgets/nav_bar.dart';
import '../widgets/upper_bar.dart';

class IssuePage extends StatelessWidget {
  const IssuePage({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        body: ListView(
          children: [
            UpperBar(),
            SizedBox(height: 15,),
            NavBar(),

          ],
        ),
      ),
    ) ;
  }
}