-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 04, 2018 at 04:11 PM
-- Server version: 5.6.20
-- PHP Version: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `feu-ams`
--
CREATE DATABASE IF NOT EXISTS `feu-ams` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `feu-ams`;

-- --------------------------------------------------------

--
-- Table structure for table `attendance_table`
--

CREATE TABLE IF NOT EXISTS `attendance_table` (
`attendance_id` int(11) NOT NULL,
  `rfid_number` bigint(30) NOT NULL,
  `time_in` text NOT NULL,
  `time_out` text NOT NULL,
  `date_in` text NOT NULL,
  `remarks` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=60 ;

--
-- Dumping data for table `attendance_table`
--

INSERT INTO `attendance_table` (`attendance_id`, `rfid_number`, `time_in`, `time_out`, `date_in`, `remarks`) VALUES
(1, 345423822236, '9:44:46 PM', '9:45:42 PM', 'Tuesday, February 13, 2018', ''),
(2, 130187123192, '9:45:04 PM', '9:45:26 PM', 'Tuesday, February 13, 2018', ''),
(3, 130187123192, '5:42:00 AM', '', 'Thursday, February 15, 2018', ''),
(4, 345423822236, '5:42:03 AM', '', 'Thursday, February 15, 2018', ''),
(5, 130187123192, '8:04:00 AM', '8:06:12 AM', 'Thursday, 15 February 2018', ''),
(6, 345423822236, '8:05:25 AM', '8:06:18 AM', 'Thursday, 15 February 2018', ''),
(7, 345423822236, '8:05:42 AM', '8:06:18 AM', 'Thursday, 15 February 2018', ''),
(8, 130187123192, '8:05:47 AM', '8:06:12 AM', 'Thursday, 15 February 2018', ''),
(9, 345423822236, '6:29:25 PM', '6:30:11 PM', 'Saturday, February 17, 2018', ''),
(10, 130187123192, '6:29:35 PM', '6:30:06 PM', 'Saturday, February 17, 2018', ''),
(11, 130187123192, '6:32:02 PM', '', 'Saturday, February 17, 2018', ''),
(12, 345423822236, '6:32:06 PM', '', 'Saturday, February 17, 2018', ''),
(13, 345423822236, '6:49:36 PM', '', 'Saturday, February 17, 2018', ''),
(14, 130187123192, '6:49:47 PM', '', 'Saturday, February 17, 2018', ''),
(15, 130187123192, '6:51:25 PM', '', 'Saturday, February 17, 2018', ''),
(16, 345423822236, '6:51:35 PM', '', 'Saturday, February 17, 2018', ''),
(17, 130187123192, '7:06:39 PM', '', 'Saturday, February 17, 2018', ''),
(18, 345423822236, '7:07:51 PM', '', 'Saturday, February 17, 2018', ''),
(19, 130187123192, '7:10:11 PM', '', 'Saturday, February 17, 2018', ''),
(20, 345423822236, '7:10:30 PM', '', 'Saturday, February 17, 2018', ''),
(21, 345423822236, '7:11:49 PM', '', 'Saturday, February 17, 2018', ''),
(22, 345423822236, '7:14:48 PM', '', 'Saturday, February 17, 2018', ''),
(23, 130187123192, '7:15:04 PM', '', 'Saturday, February 17, 2018', ''),
(24, 130187123192, '1:25:49 PM', '', 'Tuesday, February 20, 2018', ''),
(25, 130187123192, '1:25:56 PM', '', 'Tuesday, February 20, 2018', ''),
(26, 130187123192, '1:26:54 PM', '', 'Tuesday, February 20, 2018', ''),
(27, 130187123192, '1:31:07 PM', '', 'Tuesday, February 20, 2018', ''),
(28, 130187123192, '1:39:36 PM', '', 'Tuesday, February 20, 2018', ''),
(29, 345423822236, '7:37:57 PM', '8:50:08 PM', 'Tuesday, 20 February 2018', ''),
(30, 345423822236, '7:38:01 PM', '8:50:08 PM', 'Tuesday, 20 February 2018', ''),
(31, 130187123192, '8:34:35 PM', '8:49:56 PM', 'Tuesday, 20 February 2018', ''),
(32, 130187123192, '8:36:59 PM', '8:49:56 PM', 'Tuesday, 20 February 2018', ''),
(33, 345423822236, '8:41:51 PM', '8:50:08 PM', 'Tuesday, 20 February 2018', ''),
(34, 130187123192, '8:42:11 PM', '8:49:56 PM', 'Tuesday, 20 February 2018', ''),
(35, 130187123192, '8:43:04 PM', '8:49:56 PM', 'Tuesday, 20 February 2018', ''),
(36, 345423822236, '8:43:09 PM', '8:50:08 PM', 'Tuesday, 20 February 2018', ''),
(37, 345423822236, '8:54:51 PM', '', 'Tuesday, 20 February 2018', ''),
(38, 130187123192, '8:55:16 PM', '', 'Tuesday, 20 February 2018', ''),
(39, 345423822236, '8:57:03 PM', '', 'Tuesday, 20 February 2018', ''),
(40, 130187123192, '8:57:14 PM', '', 'Tuesday, 20 February 2018', ''),
(41, 130187123192, '8:58:21 PM', '', 'Tuesday, 20 February 2018', ''),
(42, 345423822236, '8:58:37 PM', '', 'Tuesday, 20 February 2018', ''),
(43, 345423822236, '9:00:09 PM', '', 'Tuesday, 20 February 2018', ''),
(44, 130187123192, '9:00:11 PM', '', 'Tuesday, 20 February 2018', ''),
(45, 130187123192, '9:02:49 PM', '', 'Tuesday, 20 February 2018', ''),
(46, 345423822236, '9:03:17 PM', '', 'Tuesday, 20 February 2018', ''),
(47, 345423822236, '9:05:21 PM', '', 'Tuesday, 20 February 2018', ''),
(48, 130187123192, '9:05:23 PM', '', 'Tuesday, 20 February 2018', ''),
(49, 345423822236, '9:07:10 PM', '', 'Tuesday, 20 February 2018', ''),
(50, 130187123192, '9:07:11 PM', '', 'Tuesday, 20 February 2018', ''),
(51, 23720810137190, '9:11:55 PM', '', 'Tuesday, 20 February 2018', ''),
(52, 130187123192, '9:12:03 PM', '', 'Tuesday, 20 February 2018', ''),
(53, 345423822236, '9:12:06 PM', '', 'Tuesday, 20 February 2018', ''),
(54, 130187123192, '10:04:34 PM', '', 'Tuesday, February 20, 2018', ''),
(55, 345423822236, '10:04:36 PM', '', 'Tuesday, February 20, 2018', ''),
(56, 23720810137190, '10:04:40 PM', '', 'Tuesday, February 20, 2018', ''),
(57, 345423822236, '8:37:40 PM', '', 'Monday, February 26, 2018', ''),
(58, 130187123192, '8:37:46 PM', '', 'Monday, February 26, 2018', ''),
(59, 23720810137190, '8:37:54 PM', '', 'Monday, February 26, 2018', '');

-- --------------------------------------------------------

--
-- Table structure for table `courses_table`
--

CREATE TABLE IF NOT EXISTS `courses_table` (
`course_id` int(11) NOT NULL,
  `course` varchar(100) NOT NULL,
  `course_main_title` text NOT NULL,
  `acad_year` varchar(100) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `courses_table`
--

INSERT INTO `courses_table` (`course_id`, `course`, `course_main_title`, `acad_year`) VALUES
(2, 'K', 'Kindergarten', '2017-2018'),
(3, 'P', 'Preparatory', '2017-2018'),
(4, 'G', 'Grade', '2017-2018');

-- --------------------------------------------------------

--
-- Table structure for table `dump_query_table`
--

CREATE TABLE IF NOT EXISTS `dump_query_table` (
`query_id` int(11) NOT NULL,
  `usage` text NOT NULL,
  `query` text NOT NULL,
  `remarks` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=39 ;

--
-- Dumping data for table `dump_query_table`
--

INSERT INTO `dump_query_table` (`query_id`, `usage`, `query`, `remarks`) VALUES
(6, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "7:37:57 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(7, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "7:38:01 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(8, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:34:35 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(9, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:36:59 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(10, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "8:41:51 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(11, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:42:11 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(12, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:43:04 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(13, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "8:43:09 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(14, 'Time Out', 'UPDATE attendance_table set time_out="8:49:56 PM" WHERE date_in = "Tuesday, 20 February 2018" AND rfid_number = 130187123192\r', 'unsynced'),
(15, 'Time Out', 'UPDATE attendance_table set time_out="8:50:08 PM" WHERE date_in = "Tuesday, 20 February 2018" AND rfid_number = 345423822236\r', 'unsynced'),
(16, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "8:54:51 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(17, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:55:16 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(18, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "8:57:03 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(19, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:57:14 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(20, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:58:21 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(21, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "8:58:37 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(22, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "9:00:09 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(23, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "9:00:11 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(24, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "9:02:49 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(25, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "9:03:17 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(26, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "9:05:21 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(27, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "9:05:23 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(28, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "9:07:10 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(29, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "9:07:11 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(30, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (23720810137190\r, "9:11:55 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(31, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "9:12:03 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(32, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "9:12:06 PM", "Tuesday, 20 February 2018")', 'unsynced'),
(33, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "10:04:34 PM", "Tuesday, February 20, 2018")', 'unsynced'),
(34, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "10:04:36 PM", "Tuesday, February 20, 2018")', 'unsynced'),
(35, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (23720810137190\r, "10:04:40 PM", "Tuesday, February 20, 2018")', 'unsynced'),
(36, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (345423822236\r, "8:37:40 PM", "Monday, February 26, 2018")', 'unsynced'),
(37, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (130187123192\r, "8:37:46 PM", "Monday, February 26, 2018")', 'unsynced'),
(38, 'Time In', 'INSERT into attendance_table (rfid_number, time_in, date_in) values (23720810137190\r, "8:37:54 PM", "Monday, February 26, 2018")', 'unsynced');

-- --------------------------------------------------------

--
-- Table structure for table `instructors_table`
--

CREATE TABLE IF NOT EXISTS `instructors_table` (
`instructor_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `academic_rankment` varchar(100) NOT NULL,
  `educational_attainment` varchar(100) NOT NULL,
  `nature_of_appointttainment` varchar(100) NOT NULL,
  `total_units` int(2) NOT NULL DEFAULT '0',
  `department_id` int(11) DEFAULT '0',
  `status` varchar(100) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `instructors_table`
--

INSERT INTO `instructors_table` (`instructor_id`, `user_id`, `academic_rankment`, `educational_attainment`, `nature_of_appointttainment`, `total_units`, `department_id`, `status`) VALUES
(1, 1, '', '', '', 0, 1, 'active'),
(2, 2, '', '', '', 0, 1, 'active'),
(3, 3, '', '', '', 0, 1, 'active');

-- --------------------------------------------------------

--
-- Table structure for table `sections_table`
--

CREATE TABLE IF NOT EXISTS `sections_table` (
`section_id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `year` varchar(100) NOT NULL,
  `section` varchar(100) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Dumping data for table `sections_table`
--

INSERT INTO `sections_table` (`section_id`, `course_id`, `year`, `section`) VALUES
(1, 2, '1', 'A'),
(2, 2, '2', 'D'),
(3, 2, '2', 'A'),
(6, 3, '3', 'A'),
(7, 2, '1', 'C'),
(8, 4, '2', 'A'),
(9, 4, '3', 'A');

-- --------------------------------------------------------

--
-- Table structure for table `settings_table`
--

CREATE TABLE IF NOT EXISTS `settings_table` (
`settings_id` int(11) NOT NULL,
  `time_in_message` text NOT NULL,
  `time_out_message` text NOT NULL,
  `gsmport` text NOT NULL,
  `rfidport` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `settings_table`
--

INSERT INTO `settings_table` (`settings_id`, `time_in_message`, `time_out_message`, `gsmport`, `rfidport`) VALUES
(1, 'Your child [name] [stdn] [sect] arrived in the school at [date]', 'Your child [name] [stdn] [sect] depart in the school at [date]', 'COM6', 'COM9');

-- --------------------------------------------------------

--
-- Table structure for table `students_table`
--

CREATE TABLE IF NOT EXISTS `students_table` (
  `student_number` int(11) NOT NULL,
  `rfid_number` bigint(30) NOT NULL,
  `user_id` int(11) NOT NULL,
  `section_id` int(11) NOT NULL,
  `contact_number` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students_table`
--

INSERT INTO `students_table` (`student_number`, `rfid_number`, `user_id`, `section_id`, `contact_number`) VALUES
(20150123, 345423822236, 5, 0, '9466320942'),
(20160076, 23720810137190, 6, 7, '09754006334'),
(201301634, 0, 4, 0, '9451347908'),
(201701004, 0, 52, 9, '9278364682'),
(201701012, 0, 53, 7, '9263547378'),
(201701735, 0, 50, 6, '9273748281'),
(2015011502, 0, 51, 8, '9753728291');

-- --------------------------------------------------------

--
-- Table structure for table `time_in_table`
--

CREATE TABLE IF NOT EXISTS `time_in_table` (
`attendance_id` int(11) NOT NULL,
  `rfid_number` bigint(30) NOT NULL,
  `time_in` text NOT NULL,
  `date_in` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `time_in_table`
--

INSERT INTO `time_in_table` (`attendance_id`, `rfid_number`, `time_in`, `date_in`) VALUES
(1, 345423822236, '8:37:40 PM', 'Monday, February 26, 2018'),
(5, 130187123192, '8:37:46 PM', 'Monday, February 26, 2018'),
(7, 23720810137190, '8:37:54 PM', 'Monday, February 26, 2018');

-- --------------------------------------------------------

--
-- Table structure for table `time_out_table`
--

CREATE TABLE IF NOT EXISTS `time_out_table` (
`attendance_id` int(11) NOT NULL,
  `rfid_number` bigint(30) NOT NULL,
  `time_in` text NOT NULL,
  `date_in` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `university_table`
--

CREATE TABLE IF NOT EXISTS `university_table` (
  `univ_id` int(1) NOT NULL DEFAULT '1',
  `acad_year` varchar(100) NOT NULL,
  `semester` varchar(100) NOT NULL,
  `attendance_mode` int(2) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `university_table`
--

INSERT INTO `university_table` (`univ_id`, `acad_year`, `semester`, `attendance_mode`) VALUES
(1, '2017-2018', '2', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users_table`
--

CREATE TABLE IF NOT EXISTS `users_table` (
`user_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(500) NOT NULL,
  `account_type` varchar(100) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `middle_name` varchar(100) NOT NULL,
  `extension` varchar(100) NOT NULL,
  `birthday` varchar(100) NOT NULL,
  `department` varchar(100) NOT NULL,
  `img_src` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=54 ;

--
-- Dumping data for table `users_table`
--

INSERT INTO `users_table` (`user_id`, `username`, `password`, `account_type`, `first_name`, `last_name`, `middle_name`, `extension`, `birthday`, `department`, `img_src`) VALUES
(1, 'teacher', '4rbKzK7xXINTNSc2cLBnjHKK6g6TXfsA_Zra_U9fFMY', 'teacher', 'Juan', 'Cruz', 'Dela', 'secret', 'august', 'CEO', ''),
(2, 'admin', '4rbKzK7xXINTNSc2cLBnjHKK6g6TXfsA_Zra_U9fFMY', 'admin', 'AdminF', 'AdminL', 'AdminM', '', '', 'DIT', ''),
(4, 'student', '4rbKzK7xXINTNSc2cLBnjHKK6g6TXfsA_Zra_U9fFMY', 'student', 'Erwin', 'Hayag', 'O', '', '', '', 'logo.png'),
(5, 'juanmoto27', '4rbKzK7xXINTNSc2cLBnjHKK6g6TXfsA_Zra_U9fFMY', 'student', 'Juan', 'Dela Cruz', 'S', '', '', '', 'character.png\r\n'),
(6, 'student3', '4rbKzK7xXINTNSc2cLBnjHKK6g6TXfsA_Zra_U9fFMY', 'student', 'MEMA', 'MOTO', 'HAHA', '', '', '', ''),
(50, 'student7', '7Vh5-ve3U91ge3Qoh2yhYgkTCJeu-GfhmTzMtZ7JECA', 'student', 'Abundo', 'Rohama', 'P.', '', '', '', ''),
(51, 'student51', '7Vh5-ve3U91ge3Qoh2yhYgkTCJeu-GfhmTzMtZ7JECA', 'student', 'Aguilar', 'Jheroneil', 'T.', '', '', '', ''),
(52, 'student52', '7Vh5-ve3U91ge3Qoh2yhYgkTCJeu-GfhmTzMtZ7JECA', 'student', 'Alayan', 'Veronica', 'A.', '', '', '', ''),
(53, 'student53', '7Vh5-ve3U91ge3Qoh2yhYgkTCJeu-GfhmTzMtZ7JECA', 'student', 'Alumbres', 'Angelito', 'G.', 'Jr', '', '', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance_table`
--
ALTER TABLE `attendance_table`
 ADD PRIMARY KEY (`attendance_id`);

--
-- Indexes for table `courses_table`
--
ALTER TABLE `courses_table`
 ADD PRIMARY KEY (`course_id`), ADD KEY `acad_year` (`acad_year`);

--
-- Indexes for table `dump_query_table`
--
ALTER TABLE `dump_query_table`
 ADD PRIMARY KEY (`query_id`);

--
-- Indexes for table `instructors_table`
--
ALTER TABLE `instructors_table`
 ADD PRIMARY KEY (`instructor_id`), ADD UNIQUE KEY `user_id_2` (`user_id`), ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `sections_table`
--
ALTER TABLE `sections_table`
 ADD PRIMARY KEY (`section_id`), ADD KEY `course_id` (`course_id`);

--
-- Indexes for table `settings_table`
--
ALTER TABLE `settings_table`
 ADD PRIMARY KEY (`settings_id`);

--
-- Indexes for table `students_table`
--
ALTER TABLE `students_table`
 ADD PRIMARY KEY (`student_number`), ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `time_in_table`
--
ALTER TABLE `time_in_table`
 ADD PRIMARY KEY (`attendance_id`), ADD UNIQUE KEY `rfid_number` (`rfid_number`);

--
-- Indexes for table `time_out_table`
--
ALTER TABLE `time_out_table`
 ADD PRIMARY KEY (`attendance_id`), ADD UNIQUE KEY `rfid_number` (`rfid_number`);

--
-- Indexes for table `university_table`
--
ALTER TABLE `university_table`
 ADD PRIMARY KEY (`acad_year`), ADD UNIQUE KEY `acad_year` (`acad_year`), ADD UNIQUE KEY `univ_id` (`univ_id`);

--
-- Indexes for table `users_table`
--
ALTER TABLE `users_table`
 ADD PRIMARY KEY (`user_id`), ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendance_table`
--
ALTER TABLE `attendance_table`
MODIFY `attendance_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=60;
--
-- AUTO_INCREMENT for table `courses_table`
--
ALTER TABLE `courses_table`
MODIFY `course_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `dump_query_table`
--
ALTER TABLE `dump_query_table`
MODIFY `query_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=39;
--
-- AUTO_INCREMENT for table `instructors_table`
--
ALTER TABLE `instructors_table`
MODIFY `instructor_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `sections_table`
--
ALTER TABLE `sections_table`
MODIFY `section_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `settings_table`
--
ALTER TABLE `settings_table`
MODIFY `settings_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `time_in_table`
--
ALTER TABLE `time_in_table`
MODIFY `attendance_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `time_out_table`
--
ALTER TABLE `time_out_table`
MODIFY `attendance_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `users_table`
--
ALTER TABLE `users_table`
MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=54;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `courses_table`
--
ALTER TABLE `courses_table`
ADD CONSTRAINT `courses_table_ibfk_1` FOREIGN KEY (`acad_year`) REFERENCES `university_table` (`acad_year`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `sections_table`
--
ALTER TABLE `sections_table`
ADD CONSTRAINT `sections_table_ibfk_1` FOREIGN KEY (`course_id`) REFERENCES `courses_table` (`course_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
