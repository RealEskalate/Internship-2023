import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/issue/presentation/widgets/upvote_downvote.dart';

class IssueBody extends StatelessWidget {
  const IssueBody({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          child: Row(
            children: [
              SizedBox(
                width: 15,
              ),
              CircleAvatar(
                backgroundColor: Colors.red,
              ),
              SizedBox(
                width: 5,
              ),
              Text(
                'Beth Slander',
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
              )
            ],
          ),
        ),
        Container(
          padding: EdgeInsets.only(left: 16, right: 16, top: 16, bottom: 7),
          child: Text(
            'The point of using Lorem Ipl distribution em Ipsum as their default model text,',
            style: TextStyle(
              fontSize: 16.0,
              color: Colors.black,
              fontWeight: FontWeight.w900,
            ),
          ),
        ),
        Container(
          padding: EdgeInsets.only(left: 16, right: 16, top: 16, bottom: 7),
          child: Text(
            'The point of using p publishing packages and wedel text, and a search for ll uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).',
            style: TextStyle(
              fontSize: 16.0,
              color: Colors.black,
            ),
          ),
        ),
        Divider(),
        //vote s
        UpvoteDownvote(),
      ],
    );
  }
}
