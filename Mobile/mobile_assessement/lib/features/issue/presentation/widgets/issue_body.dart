import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

class IssueBody extends StatelessWidget {
  const IssueBody({super.key});

  @override
  Widget build(BuildContext context) {
    return  Column(
      children: [
        Container(
          child: Row(
            children: [
              SizedBox(width: 15,),
              CircleAvatar(
                backgroundColor: Colors.red,
              ),
               SizedBox(width: 5,),
              Text('Beth Slander',style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),)

            ],
          ),
        )
      ],
    );
  }
}