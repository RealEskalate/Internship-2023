import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/issue/presentation/widgets/issue_body.dart';

import '../widgets/nav_bar.dart';
import '../widgets/upper_bar.dart';

class IssuePage extends StatelessWidget {
  const IssuePage({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        body: ListView(
          children: [
            UpperBar(),
            SizedBox(
              height: 15,
            ),
            NavBar(),
            SizedBox(
              height: 40,
            ),
            IssueBody(),
          ],
        ),
      ),
    );
  }
}
