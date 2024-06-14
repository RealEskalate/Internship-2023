import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../core/utils/ui_converter.dart';

class InfoCard extends StatelessWidget {
  InfoCard({super.key});
  String name = 'Beth Slander';
  String post_time = '12 November 2022 | 12:08 am';

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(
          top: UIConverter.getComponentHeight(context, 70),
          left: UIConverter.getComponentWidth(context, 15),
          right: UIConverter.getComponentWidth(context, 15)),
      child: Container(
        decoration: BoxDecoration(
          boxShadow: [
            BoxShadow(
              color: Colors.grey.withOpacity(0.3),
              spreadRadius: UIConverter.getComponentWidth(context, 5),
              blurRadius: UIConverter.getComponentWidth(context, 9),
              offset: Offset(UIConverter.getComponentWidth(context, 0),
                  UIConverter.getComponentHeight(context, 9)),
            )
          ],
          color: Colors.white,
        ),
        width: UIConverter.getComponentWidth(context, 400),
        height: UIConverter.getComponentWidth(context, 100),
        // mainAxisAlignment: MainAxisAlignment.spaceBetween,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                CircleAvatar(
                  backgroundImage: AssetImage("pp.jpg"),
                ),
                SizedBox(
                  width: UIConverter.getComponentHeight(context, 13),
                ),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      name,
                      style: const TextStyle(color: Color(0xFF222222)),
                    ),
                    Text(
                      post_time,
                      style: const TextStyle(color: Color(0xFFABABAB)),
                    ),
                  ],
                ),
              ],
            ),
            SizedBox(
              width: UIConverter.getComponentWidth(context, 100),
              child: Padding(
                padding: EdgeInsets.only(
                    bottom: UIConverter.getComponentHeight(context, 10)),
                child: Container(
                  child: Text(
                      "Join Hackathon competition prepared for all African students "),
                ),
              ),
            ),
            SizedBox(
              width: UIConverter.getComponentWidth(context, 100),
              child: Container(
                child: Text(
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vulputate libero et velit interdum, ac aliquet odio mattis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos."),

                // ),
              ),
            ),
            SizedBox(
              child: Text("Read more"),
            ),
            Divider(
              color: Colors.grey,
            ),
            Row(children: [
              Icon(Icons.arrow_upward),
              Text("183"),
              Icon(Icons.arrow_downward),
              Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  Icon(Icons.mode_comment_outlined),
                  Text("24 comments")
                ],
              )
            ])
          ],
        ),
      ),
    );
  }
}
