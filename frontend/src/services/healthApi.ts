import api from './api';
import type { ApiResponse, HealthStatus } from '../types/api';

export async function fetchHealthStatus(): Promise<ApiResponse<HealthStatus>> {
  const response = await api.get<ApiResponse<HealthStatus>>('/health');
  return response.data;
}
