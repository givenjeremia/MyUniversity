-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Inang: 127.0.0.1
-- Waktu pembuatan: 15 Des 2020 pada 17.59
-- Versi Server: 5.5.32
-- Versi PHP: 5.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Basis data: `myuniversity`
--
CREATE DATABASE IF NOT EXISTS `myuniversity` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `myuniversity`;

-- --------------------------------------------------------

--
-- Struktur dari tabel `falkutas`
--

CREATE TABLE IF NOT EXISTS `falkutas` (
  `id` varchar(20) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `dekan` varchar(45) DEFAULT NULL,
  `wakil_dekan` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `falkutas`
--

INSERT INTO `falkutas` (`id`, `nama`, `dekan`, `wakil_dekan`) VALUES
('1', 'Fakultas Teknik', 'Salsabilla Aryaning Putri ', 'Devina Aprilia Ariyanti M.Kom'),
('2', 'Fakultas Farmasi', 'Devina Aprilia', 'Given Jeremia'),
('3', 'Fakultas Pertanian', 'Given Jeremia', 'Salsabilla Aryaning Putri'),
('4', 'Fakultas Kedokteran', 'Salsa', 'Devina'),
('5', 'Fakultas Bisnis dan Ekonomika', 'GIven', 'Jeremia');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jabatan`
--

CREATE TABLE IF NOT EXISTS `jabatan` (
  `id` varchar(20) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `jabatan`
--

INSERT INTO `jabatan` (`id`, `nama`) VALUES
('1', 'Dosen'),
('2', 'Dekan'),
('3', 'Wakil Dekan'),
('4', 'Cleaning Service'),
('5', 'Ketua Jurusan'),
('6', 'Wakil Ketua Jurusan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jadwal`
--

CREATE TABLE IF NOT EXISTS `jadwal` (
  `id` int(11) NOT NULL,
  `kelas_id` varchar(20) NOT NULL,
  `mata_kuliah_id` varchar(20) NOT NULL,
  `jam` varchar(45) NOT NULL,
  `hari` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_kelas_has_mata_kuliah_mata_kuliah1_idx` (`mata_kuliah_id`),
  KEY `fk_kelas_has_mata_kuliah_kelas1_idx` (`kelas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `jadwal`
--

INSERT INTO `jadwal` (`id`, `kelas_id`, `mata_kuliah_id`, `jam`, `hari`) VALUES
(1, '101', '1011', '07.00 - 09.45', 'Senin'),
(2, '101', '1011', '10.40 - 12.30', 'Kamis'),
(3, '101', '1012', '07.00 - 09.45', 'Selasa'),
(4, '201', '2011', '1400', 'Senin'),
(5, '201', '2011', '13.00', 'Seninn'),
(6, '101', '1011', '12.00 Oke', 'Selasa');

-- --------------------------------------------------------

--
-- Struktur dari tabel `jurusan`
--

CREATE TABLE IF NOT EXISTS `jurusan` (
  `id` varchar(20) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `ketua_jurusan` varchar(45) DEFAULT NULL,
  `wakil_ketua` varchar(45) DEFAULT NULL,
  `falkutas_id` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_jurusan_falkutas_idx` (`falkutas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `jurusan`
--

INSERT INTO `jurusan` (`id`, `nama`, `ketua_jurusan`, `wakil_ketua`, `falkutas_id`) VALUES
('101', 'Jurusan Teknik Informatika', 'Devina', 'Salsabilla', '1'),
('102', 'Multimedia', 'Salsa', 'Billa', '1'),
('201', 'Jurusan Farmasi Klinis', 'Devina', 'Sabila', '2'),
('301', 'Jurusan Agribisnis', 'Given', 'Aprilia', '3'),
('401', 'Pendidikan Dokter Gigi', 'Salsabillaning', 'Putri', '4');

-- --------------------------------------------------------

--
-- Struktur dari tabel `karyawan`
--

CREATE TABLE IF NOT EXISTS `karyawan` (
  `id` varchar(20) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `tanggalLahir` date DEFAULT NULL,
  `telepon` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `jabatan_id` varchar(20) NOT NULL,
  `falkutas_id` varchar(20) NOT NULL,
  `jurusan_id` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_karyawan_jabatan1_idx` (`jabatan_id`),
  KEY `fk_karyawan_falkutas1_idx` (`falkutas_id`),
  KEY `fk_karyawan_jurusan1_idx` (`jurusan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `karyawan`
--

INSERT INTO `karyawan` (`id`, `nama`, `alamat`, `tanggalLahir`, `telepon`, `email`, `jabatan_id`, `falkutas_id`, `jurusan_id`) VALUES
('101001', 'Given', 'Jl Mojo Kidul Blok B/3', '2020-10-07', '82444444', 'jj@gmail.com', '1', '1', '101'),
('101002', 'Depin', 'Banjar', '2020-10-07', '465645646', 'jj@gmail.co', '2', '1', '101'),
('201001', 'Jeremiaaa', 'Simolangan', '2020-10-07', '08152557444', 'jj@gmail.com.id', '3', '2', '201');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kelas`
--

CREATE TABLE IF NOT EXISTS `kelas` (
  `id` varchar(20) NOT NULL,
  `nama_ruang` varchar(45) NOT NULL,
  `falkutas_id` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_kelas_falkutas1_idx` (`falkutas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `kelas`
--

INSERT INTO `kelas` (`id`, `nama_ruang`, `falkutas_id`) VALUES
('101', 'TC 4.1', '1'),
('201', 'FG 6.2', '2');

-- --------------------------------------------------------

--
-- Struktur dari tabel `krs`
--

CREATE TABLE IF NOT EXISTS `krs` (
  `id` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `mahasiswa_nrp` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_krs_mahasiswa1_idx` (`mahasiswa_nrp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `krs`
--

INSERT INTO `krs` (`id`, `tanggal`, `mahasiswa_nrp`) VALUES
(1, '2020-12-09', '101002'),
(2, '2020-12-09', '201001'),
(3, '2020-12-15', '401001'),
(4, '2020-12-15', '101002'),
(5, '2020-12-15', '401001');

-- --------------------------------------------------------

--
-- Struktur dari tabel `krs_details`
--

CREATE TABLE IF NOT EXISTS `krs_details` (
  `id_jadwal` int(11) NOT NULL,
  `id_krs` int(11) NOT NULL,
  PRIMARY KEY (`id_jadwal`,`id_krs`),
  KEY `fk_jadwal_has_krs_krs1_idx` (`id_krs`),
  KEY `fk_jadwal_has_krs_jadwal1_idx` (`id_jadwal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `krs_details`
--

INSERT INTO `krs_details` (`id_jadwal`, `id_krs`) VALUES
(1, 1),
(1, 2),
(3, 4),
(4, 5);

-- --------------------------------------------------------

--
-- Struktur dari tabel `mahasiswa`
--

CREATE TABLE IF NOT EXISTS `mahasiswa` (
  `nrp` varchar(20) NOT NULL,
  `angkatan` int(4) DEFAULT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `tanggalLahir` datetime DEFAULT NULL,
  `telepon` varchar(13) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `falkutas_id` varchar(20) NOT NULL,
  `jurusan_id` varchar(20) NOT NULL,
  `ormawa_idormawa` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`nrp`),
  KEY `fk_mahasiswa_falkutas1_idx` (`falkutas_id`),
  KEY `fk_mahasiswa_jurusan1_idx` (`jurusan_id`),
  KEY `fk_mahasiswa_ormawa1_idx` (`ormawa_idormawa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `mahasiswa`
--

INSERT INTO `mahasiswa` (`nrp`, `angkatan`, `nama`, `alamat`, `tanggalLahir`, `telepon`, `email`, `falkutas_id`, `jurusan_id`, `ormawa_idormawa`) VALUES
('101002', 2019, 'salsa', 'surabaya', '2020-10-27 00:00:00', '0897628123', 'salsabilla@gmail.com', '1', '101', '11'),
('201001', 2019, 'Given', 'Jakarta', '2001-07-12 00:00:00', '08902184812', 'given@yahoo.com', '1', '201', '21'),
('401001', 2018, 'GivenJ', 'JakartaTimur', '2001-07-18 00:00:00', '089021848234', 'given231@yahoo.com', '2', '201', '21');

-- --------------------------------------------------------

--
-- Struktur dari tabel `mata_kuliah`
--

CREATE TABLE IF NOT EXISTS `mata_kuliah` (
  `id` varchar(20) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `jumlah_sks` int(11) DEFAULT NULL,
  `jurusan_id` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_mata_kuliah_jurusan1_idx` (`jurusan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `mata_kuliah`
--

INSERT INTO `mata_kuliah` (`id`, `nama`, `jumlah_sks`, `jurusan_id`) VALUES
('1011', 'Alpro', 6, '101'),
('1012', 'Matdis', 4, '101'),
('2011', 'Kimia', 6, '201'),
('4011', 'biologi', 4, '401');

-- --------------------------------------------------------

--
-- Struktur dari tabel `nilai`
--

CREATE TABLE IF NOT EXISTS `nilai` (
  `id` int(11) NOT NULL,
  `nilai` double NOT NULL,
  `krs_details_id_jadwal` int(11) NOT NULL,
  `krs_details_id_krs` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_nilai_krs_details1_idx` (`krs_details_id_jadwal`,`krs_details_id_krs`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `nilai`
--

INSERT INTO `nilai` (`id`, `nilai`, `krs_details_id_jadwal`, `krs_details_id_krs`) VALUES
(1, 90, 1, 1),
(2, 75, 1, 2);

-- --------------------------------------------------------

--
-- Struktur dari tabel `ormawa`
--

CREATE TABLE IF NOT EXISTS `ormawa` (
  `idormawa` varchar(20) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `ketua_ormana` varchar(45) DEFAULT NULL,
  `falkutas_id` varchar(20) NOT NULL,
  PRIMARY KEY (`idormawa`),
  KEY `fk_ormawa_falkutas1_idx` (`falkutas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `ormawa`
--

INSERT INTO `ormawa` (`idormawa`, `nama`, `ketua_ormana`, `falkutas_id`) VALUES
('11', 'KSM Teknik Informatika', NULL, '1'),
('21', 'KSM Farmasi', NULL, '2'),
('31', 'KSM Agribisnis', NULL, '3'),
('32', 'Hima FP', NULL, '3'),
('51', 'Hima FBE', NULL, '5');

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `jadwal`
--
ALTER TABLE `jadwal`
  ADD CONSTRAINT `fk_kelas_has_mata_kuliah_kelas1` FOREIGN KEY (`kelas_id`) REFERENCES `kelas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_kelas_has_mata_kuliah_mata_kuliah1` FOREIGN KEY (`mata_kuliah_id`) REFERENCES `mata_kuliah` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `jurusan`
--
ALTER TABLE `jurusan`
  ADD CONSTRAINT `fk_jurusan_falkutas` FOREIGN KEY (`falkutas_id`) REFERENCES `falkutas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `karyawan`
--
ALTER TABLE `karyawan`
  ADD CONSTRAINT `fk_karyawan_falkutas1` FOREIGN KEY (`falkutas_id`) REFERENCES `falkutas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_karyawan_jabatan1` FOREIGN KEY (`jabatan_id`) REFERENCES `jabatan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_karyawan_jurusan1` FOREIGN KEY (`jurusan_id`) REFERENCES `jurusan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `kelas`
--
ALTER TABLE `kelas`
  ADD CONSTRAINT `fk_kelas_falkutas1` FOREIGN KEY (`falkutas_id`) REFERENCES `falkutas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `krs`
--
ALTER TABLE `krs`
  ADD CONSTRAINT `fk_krs_mahasiswa1` FOREIGN KEY (`mahasiswa_nrp`) REFERENCES `mahasiswa` (`nrp`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `krs_details`
--
ALTER TABLE `krs_details`
  ADD CONSTRAINT `fk_jadwal_has_krs_jadwal1` FOREIGN KEY (`id_jadwal`) REFERENCES `jadwal` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_jadwal_has_krs_krs1` FOREIGN KEY (`id_krs`) REFERENCES `krs` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD CONSTRAINT `fk_mahasiswa_falkutas1` FOREIGN KEY (`falkutas_id`) REFERENCES `falkutas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_mahasiswa_jurusan1` FOREIGN KEY (`jurusan_id`) REFERENCES `jurusan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_mahasiswa_ormawa1` FOREIGN KEY (`ormawa_idormawa`) REFERENCES `ormawa` (`idormawa`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `mata_kuliah`
--
ALTER TABLE `mata_kuliah`
  ADD CONSTRAINT `fk_mata_kuliah_jurusan1` FOREIGN KEY (`jurusan_id`) REFERENCES `jurusan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `nilai`
--
ALTER TABLE `nilai`
  ADD CONSTRAINT `fk_nilai_krs_details1` FOREIGN KEY (`krs_details_id_jadwal`, `krs_details_id_krs`) REFERENCES `krs_details` (`id_jadwal`, `id_krs`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `ormawa`
--
ALTER TABLE `ormawa`
  ADD CONSTRAINT `fk_ormawa_falkutas1` FOREIGN KEY (`falkutas_id`) REFERENCES `falkutas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
