import '../../../../core/utils/colors.dart';
import 'package:flutter/material.dart';

import '../widgets/everyday.dart';
import '../widgets/search_bar.dart';

class Weather extends StatelessWidget {
  const Weather({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    return Scaffold(
      backgroundColor: Color(0xFFF2F2F2),
      body: Padding(
        padding: const EdgeInsets.fromLTRB(0, 40, 0, 0),
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                IconButton(
                  onPressed: () {
                    Navigator.pop(context);
                  },
                  icon: Icon(Icons.arrow_back),
                ),
                Column(
                  children: [
                    Text("New Mexico",
                        style: TextStyle(
                            color: Color(0xff211772),
                            fontWeight: FontWeight.w900)),
                    Text("sun,November 16",
                        style: TextStyle(
                            color: Color(0xFF575757),
                            fontWeight: FontWeight.w100))
                  ],
                ),
                IconButton(onPressed: () {}, icon: Icon(Icons.favorite))
              ],
            ),
            Center(
              child: Image.asset("images/rainy_lightning_windy_sunny.png"),
            ),
            Align(
                alignment: Alignment.centerLeft,
                child: Column(
                  children: [
                    Text(
                      "Mostly Sunny",
                      style: TextStyle(color: Color(0xff211772), fontSize: 20),
                    ),
                    Text("30",
                        style: TextStyle(
                          color: Color(0xff211772),
                          fontSize: 40,
                        ))
                  ],
                )),
            Expanded(
              child: Container(
                decoration: BoxDecoration(
                    color: Color(0xff211772),
                    borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(40),
                        topRight: Radius.circular(40))),
                child: Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          "Every Day",
                          style: TextStyle(color: Colors.white),
                        ),
                        EveryDay(),
                        EveryDay(),
                        EveryDay(),
                        EveryDay(),
                        EveryDay(),
                        EveryDay()
                      ]),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
