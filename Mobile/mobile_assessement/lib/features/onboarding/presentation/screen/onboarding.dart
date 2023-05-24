import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';
import 'package:flutter_svg/svg.dart';
import 'package:mobile_assessement/core/utils/colors.dart';
import '../../../../core/utils/style.dart';
import '../../../../core/utils/ui_converter.dart';

class Onboarding extends StatelessWidget {
  const Onboarding({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        color: Color(0xFF211772),
        child: Column(children: [
          Padding(
            padding: EdgeInsets.only(
              top: UIConverter.getComponentHeight(context, 100),
              bottom: UIConverter.getComponentHeight(context, 10),
            ),
            child: Container(
                width: 300,
                height: 300,
                child: SvgPicture.asset("images/Group.svg")),
          ),
          Padding(
            padding: EdgeInsets.all(UIConverter.getComponentWidth(context, 50)),
            child: Container(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    child: Text(
                      "Weather",
                      style: myTextStyle.copyWith(
                          fontSize: 30, color: Color(0xFFFFBA25)),
                    ),
                  ),
                  Padding(
                    padding: EdgeInsets.only(
                      top: UIConverter.getComponentHeight(context, 10),
                      // bottom: UIConverter.getComponentHeight(context, 20),
                    ),
                    child: Container(
                      child: Text(
                        "Forecast App.",
                        style: myTextStyle.copyWith(
                            fontSize: 20, color: Colors.white),
                      ),
                    ),
                  ),
                  Padding(
                    padding: EdgeInsets.only(
                        top: UIConverter.getComponentHeight(context, 5)),
                    child: Container(
                      child: Text(
                        "It's the newest weather app. It has a bunch of features and that includes most of the ones that every weather app has.",
                        style: myTextStyle.copyWith(
                            color: Colors.white, fontSize: 15),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
          Padding(
              padding: EdgeInsets.only(
                  bottom: UIConverter.getComponentHeight(context, 40)),
              child: ElevatedButton(
                style: ElevatedButton.styleFrom(
                  padding: EdgeInsets.all(10),
                  backgroundColor: Color(0xFFFFBA25),
                ),
                onPressed: () {},
                child: Text("Get Started"),
              ))
        ]),
      ),
    );
  }
}
