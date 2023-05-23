import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:mobile_assessement/features/weatherify/presentation/widgets/action_button.dart';

import '../../../../core/utils/colors.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                "Choose a city",
                style: TextStyle(
                    color: primaryTextColor,
                    fontSize: MediaQuery.of(context).size.height * 0.03,
                    fontWeight: FontWeight.bold),
              ),
              Row(
          children: [
            Expanded(
              child: SizedBox(
                height: MediaQuery.of(context).size.height * 0.05,
                child: Center(
                  child: TextField(
                    decoration: InputDecoration(
                      hintText: 'Search a new city',
                      hintStyle: const TextStyle(
                          fontFamily: "Poppins", fontWeight: FontWeight.w100),
                      border: InputBorder.none,
                      contentPadding:
                          EdgeInsets.symmetric(horizontal: MediaQuery.of(context).size.width * 0.04),
                    ),
                  ),
                ),
              ),
            ),
            ActionButton(
              height: MediaQuery.of(context).size.height * 0.05,
              child: Icon(Icons.search),
            )
          ],
        ),
            ],
          ),
        ),
      ),
    );
  }
}
