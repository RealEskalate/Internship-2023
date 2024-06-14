import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

import '../../../../core/utils/ui_converter.dart';

class InfoDetail extends StatelessWidget {
  String name = "Beth";
  String resource_name =  "Intro to Algo.doc";
  

  String post_time = "12 November 2022 | 12:08 am";

  InfoDetail({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                Icon(Icons.arrow_back),
              ],
            ),
            SizedBox(
              child: Text(""),
            ),
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
              child: Text(
                  "Horem ipsum dolor sit amet, consectetur adipiscing elit. Etiam eu turpis molestie, dictum est a, mattis tellus. Sed dignissim, metus nec fringilla accumsan, risus sem sollicitudin lacus, ut interdum tellus elit sed risus. Maecenas eget condimentum velit, sit amet feugiat lectus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent auctor purus luctus enim egestas, ac scelerisque ante pulvinar. Donec ut rhoncus ex. Suspendisse ac rhoncus nisl, eu tempor urna. Curabitur vel bibendum lorem. Morbi convallis convallis diam sit amet lacinia. Aliquam in elementum tellus."),

            ),
            Text("Resources"),

            Row(

          
  
    
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            ClipRRect(
              // borderRadius:
              //     BorderRadius.circular(UIConverter.getComponentWidth(context, 15)),
              child: Image.asset(
                "articleReadingFasionImage1",
                width: UIConverter.getComponentWidth(context, 38),
                height: UIConverter.getComponentHeight(context, 38),
              ),
            ),
            SizedBox(
              width: UIConverter.getComponentHeight(context, 13),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  name,
                  style: const TextStyle(color: Colors.black),
                ),
                Text(
                  post_time,
                  style: const TextStyle(color: Colors.grey),
                ),
              ],
            ),
          ],
        ),
        const Text("128 KB")
      ],
    ),
            ],)

          
        ),
      
    );
  }
}
