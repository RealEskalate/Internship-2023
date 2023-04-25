import 'package:flutter/material.dart';
import 'dart:math';

class ArticleInfo extends StatelessWidget {
  const ArticleInfo({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    final screenHeight = MediaQuery.of(context).size.height;
    return Expanded(
        flex: 1,
        child: Container(
          margin: const EdgeInsets.fromLTRB(20, 0, 0, 0),
          height: screenHeight * 0.19,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "STUDENTS SHOULD WORK ON IMPROVING THEIR WRITING SKILL",
                style: TextStyle(
                    fontSize: min(screenWidth * 0.04, screenHeight * 0.04),
                    fontFamily: "Urbanist",
                    color: const Color(0xFF4D4A49)),
              ),
              ElevatedButton(
                  style: ButtonStyle(
                      backgroundColor: MaterialStateProperty.all<Color>(
                          const Color(0xFF5D5F6F))),
                  onPressed: () {},
                  child: const Text(
                    "Education",
                    style: TextStyle(
                        fontFamily: "Poppins", fontWeight: FontWeight.w700),
                  )),
              const Text(
                "By John Doe",
                style: TextStyle(
                  fontFamily: "Poppins",
                ),
              )
            ],
          ),
        ));
  }
}
