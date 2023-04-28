import 'package:dartsmiths/core/utils/colors.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../core/utils/ui_converter.dart';

class ProfilePic extends StatelessWidget {
  const ProfilePic({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
        padding: EdgeInsets.only(
            right: UIConverter.getComponentWidth(context, 10),
            top: UIConverter.getComponentHeight(context, 5)),
        child: Stack(
          children: [
            CircleAvatar(
                backgroundImage: AssetImage("assets/images/backgrd.jpg")),
            Padding(
              padding: EdgeInsets.only(
                  left: UIConverter.getComponentWidth(context, 2.5),
                  bottom: UIConverter.getComponentHeight(context, 12)),
              child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Container(
                      decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(
                            UIConverter.getComponentWidth(context, 10),
                          ),
                          border: Border.all(color: whiteColor, width: 2)),
                      width: UIConverter.getComponentWidth(context, 15),
                      height: UIConverter.getComponentWidth(context, 15),
                    )
                  ]),
            ),
          ],
        ));
  }
}
