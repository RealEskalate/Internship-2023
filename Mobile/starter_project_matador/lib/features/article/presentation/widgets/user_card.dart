import 'package:flutter/material.dart';

class UserCard extends StatelessWidget {
  final String imageUrl;
  final String name;
  final String postedTime;

  const UserCard(
      {Key? key,
      required this.imageUrl,
      required this.name,
      required this.postedTime})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Row(
          children: [
            Image.asset(height: width * 0.1, width: width * 0.1, imageUrl),
            SizedBox(
              width: width * 0.035,
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  name,
                  style: TextStyle(fontWeight: FontWeight.w500, fontSize: 14),
                ),
                Text(
                  postedTime,
                  style: TextStyle(fontWeight: FontWeight.w900, fontSize: 18),
                )
              ],
            )
          ],
        ),
        const Icon(Icons.bookmark_border, color: Color.fromRGBO(55, 106, 237, 1.0),)
      ],
    );
  }
}
