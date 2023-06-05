import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';

class UpvoteDownvote extends StatelessWidget {
  const UpvoteDownvote({super.key});

  @override
  Widget build(BuildContext context) {
    return Row(
  mainAxisAlignment: MainAxisAlignment.spaceBetween,
  children: [
    Row(
      children: [
        SizedBox(width: 15,),
        Icon(Icons.arrow_upward),
        Text('5'),
        SizedBox(width: 7,),
        Icon(Icons.arrow_downward),
      ],
    ),
    Row(
      children: [
        Icon(Icons.message),
        Text('24 comments'),
        SizedBox(width: 15,)
      ],
    ),
  ],
);
  }
}